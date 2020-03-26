using System;
using System.Collections.Generic;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class OtherMember
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public int PeopleLivingWith { get; set; }
    }
}
