using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing
{
    class ProcessData
    {
        public event EventHandler<ParsingEventArgs> ParsingComplited;

        public async void GetPreDataAsync()
        {
            Console.WriteLine("Парсинг начат!");

            Container container = new Container();

            var loader = new HtmlLoader(String.Empty);
            await Task.Run(() => loader.GetSourceAsync());

            var getter = new InfoGetter(loader.Source);
            await Task.Run(() => getter.GetDocumentAsync());

            container._linkList = getter.Parse(container.BaseTag, container.AtributeTag);
            container._nameList = getter.Parse(container.BaseTag, container.AtributeTagName);

            await Task.Run(() => GetForecastAsync(container));
        }


        private async void GetForecastAsync(Container container)
        {
            for (int i = 0; i < container._linkList.Count; i++)
            {
                Console.WriteLine($"{container._linkList[i]}");
                var loader = new HtmlLoader(container._linkList[i]);
                await Task.Run(() => loader.GetSourceAsync());

                var getter = new InfoGetter(loader.Source);
                await Task.Run(() => getter.GetDocumentAsync());

                List<string> temperature = getter.ParseLink(container.TempTomorrowTag, container.ClassTitleTempTomorrow);
                container._tempTomorrowNight.Add(temperature[2].Replace("−", "-"));
                container._tempTomorrowDay.Add(temperature[3].Replace("−", "-"));

                List<string> precip = getter.ParseLink(container.PrecipTag, container.ClassTitlePrecip, container.PrecipAtributeTag);
                container._precip.Add(precip[0]);
            }

            for (int i = 0; i < container._nameList.Count; i++)
            {
                Console.WriteLine($"{container._nameList[i]} {container._tempTomorrowNight[i]} {container._tempTomorrowDay[i]} {container._precip[i]}");
            }

            Console.WriteLine("Парсинг завершен!");

            ParsingComplited?.Invoke(this, new ParsingEventArgs(container._nameList, container._tempTomorrowNight, container._tempTomorrowDay, 
                                                                container._precip, container._linkList));
        }
    }
}
