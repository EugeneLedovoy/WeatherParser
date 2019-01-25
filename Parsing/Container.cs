using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing
{
    internal class Container
    {
        public string BaseTag { get; } = "#noscript a";
        public string AtributeTag { get; } = "href";
        public string AtributeTagName { get; } = "data-name";

        public string ClassTitleTempTomorrow { get; } = "unit unit_temperature_c";
        public string TempTomorrowTag { get; } = "span";

        public string PrecipTag { get; } = "div";
        public string ClassTitlePrecip { get; } = "tab  tooltip";
        public string PrecipAtributeTag { get; } = "data-text";


        internal List<string> _nameList = new List<string>();
        internal List<string> _linkList = new List<string>();

        internal List<string> _tempTomorrowNight = new List<string>();
        internal List<string> _tempTomorrowDay = new List<string>();
        internal List<string> _precip = new List<string>();
    }
}
