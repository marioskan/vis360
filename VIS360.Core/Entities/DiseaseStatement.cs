using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class DiseaseStatement 
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? OtherMemberID { get; set; }

        public bool Coronavirus { get; set; }
        public Diagnose Diagnose { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DiagnoseDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime HospitalAdmission { get; set; }
        public string HospitalName { get; set; }

        public virtual User User { get; set; }
        public virtual OtherMember OtherMember { get; set; }
    }
}
