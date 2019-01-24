using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing
{
    partial class ProcessData
    {
        public event EventHandler<ParsingEventArgs> ParsingComplited;

        public async void GetPreDataAsync()
        {
            Console.WriteLine("Парсинг начат!");

            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            var loader = new HtmlLoader(String.Empty);
            try
            {
                await Task.Run(() => loader.GetSourceAsync(token), token);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Операция загрузки Html-страницы отменена. {e.Message}");
            }

            var getter = new InfoGetter(loader.Source);
            try
            {
                await Task.Run(() => getter.GetDocumentAsync(token), token);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"Операция построения DOM-документа отменена. {e.Message}");
            }

            _linkList = getter.Parse(BaseTag, AtributeTag);
            _nameList = getter.Parse(BaseTag, AtributeTagName);

            await Task.Run(() => GetForecastAsync());

        }

        private async void GetForecastAsync()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            for (int i = 0; i < _linkList.Count; i++)
            {
                Console.WriteLine($"{_linkList[i]}");

                var loader = new HtmlLoader(_linkList[i]);
                try
                {
                    await Task.Run(() => loader.GetSourceAsync(token), token);
                }
               catch (OperationCanceledException e)
                {
                    Console.WriteLine($"Операция загрузки Html-страницы отменена. {e.Message}");
                }

                var getter = new InfoGetter(loader.Source);
                try
                {
                    await Task.Run(() => getter.GetDocumentAsync(token), token);
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine($"Операция построения DOM-документа отменена. {e.Message}");
                }

                List<string> temp = getter.ParseLink(TempTomorrowTag, ClassTitleTempTomorrow);
                _tempTomorrowNight.Add(temp[2].MinusHelper());
                _tempTomorrowDay.Add(temp[3].MinusHelper());

                List<string> precip = getter.ParseLink(PrecipTag, ClassTitlePrecip, PrecipAtributeTag);
                _precip.Add(precip[0]);
            }

            for (int i = 0; i < _nameList.Count; i++)
            {
                Console.WriteLine($"{_nameList[i]} {_tempTomorrowNight[i]} {_tempTomorrowDay[i]} {_precip[i]}");
            }

            Console.WriteLine("Парсинг завершен!");
            ParsingComplited?.Invoke(this, new ParsingEventArgs(_nameList, _tempTomorrowNight, _tempTomorrowDay, _precip, _linkList));
        }
    }
}
