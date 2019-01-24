using System;
using System.Collections.Generic;

namespace Parsing
{
    public class ParsingEventArgs: EventArgs
    {
        public List<string> ToDbCityName;
        public List<string> ToDbTempTomorrowNight;
        public List<string> ToDbTempTomorrowDay;
        public List<string> ToDbPrecip;
        public List<string> HrefSublink;

        public ParsingEventArgs(List<string> NameList, List<string> TempTomorrowNight, List<string> TempTomorrowDay,
                                List<string> Precip, List<string> LinkList)
        {
            ToDbCityName = NameList;
            ToDbTempTomorrowNight = TempTomorrowNight;
            ToDbTempTomorrowDay = TempTomorrowDay;
            ToDbPrecip = Precip;
            HrefSublink = LinkList;
        }

    }
}