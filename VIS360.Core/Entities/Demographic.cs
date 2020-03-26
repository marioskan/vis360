using System;
using System.Collections.Generic;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class Demographic
    {
        public string City { get; set; }
        public Education Education { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public Work Work { get; set; }
        public int Roommates { get; set; }
        public List<RoommateRelations> RoommateRelations { get; set; }
        public FinancialStatus FinancialStatus { get; set; }
        public List<Industries> Industries { get; set; }
    }
}
