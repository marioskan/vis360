using System;
using System.Collections.Generic;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class Help
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public HelpType HelpType { get; set; }
        public bool VolunteerPush { get; set; }
        public bool TownPush { get; set; }
    }
}
