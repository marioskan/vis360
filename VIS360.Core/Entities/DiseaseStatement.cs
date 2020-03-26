using System;
using System.Collections.Generic;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class DiseaseStatement : OtherMember
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Coronavirus { get; set; }
        public Diagnose Diagnose { get; set; }
        public DateTime DiagnoseDate { get; set; }
        public DateTime HospitalAdmission { get; set; }
        public string HospitalName { get; set; }

        public virtual User User { get; set; }
    }
}
