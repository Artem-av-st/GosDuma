using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GosDumaApiIntegration.Model
{
    public class Deputy
    {
        public int Id { get; }
        public string Name { get; }
        public string Position { get;  }
        public bool IsCurrent { get; }
        public List<Faction> Factions { get; set; }

        public Deputy(int id, string name, string position, bool isCurrent)
        {
            Name = name;
            Position = position;
            Id = id;
            IsCurrent = isCurrent;
        }

        public class Faction
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }

        }

        public enum DeputyPosition
        {
            SfMember,
            GdMember,
            Any
        }
    }
}
