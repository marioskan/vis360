using System;
using System.Collections.Generic;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class OtherMember
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public int PeopleLivingWith { get; set; }

        public virtual User User { get; set; }
        public virtual CovidStatus CovidStatus { get; set; }
        public virtual DiseaseStatement DiseaseStatement { get; set; }
    }
}
