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
        public string BaseTag { get; } = "#noscript a";
        public string AtributeTag { get; } = "href";
        public string AtributeTagName { get; } = "data-name";

        public string ClassTitleTempTomorrow { get; } = "unit unit_temperature_c";
        public string TempTomorrowTag { get; } = "span";

        public string PrecipTag { get; } = "div";
        public string ClassTitlePrecip { get; } = "tab  tooltip";
        public string PrecipAtributeTag { get; } = "data-text";


        private List<string> _nameList = new List<string>();
        private List<string> _linkList = new List<string>();

        private List<string> _tempTomorrowNight = new List<string>();
        private List<string> _tempTomorrowDay = new List<string>();
        private List<string> _precip = new List<string>();

        private CancellationTokenSource _tokenSource;
    }
}
