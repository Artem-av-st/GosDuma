using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosDumaApiIntegration.Model
{
    /*public class Faction
    {
        public string id { get; set; }
        public string name { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }*/

    public class RootObject
    {
        public string id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public bool isCurrent { get; set; }
        public List<Faction> factions { get; set; }
    }
}
