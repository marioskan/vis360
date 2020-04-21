using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class Demographic
    {
        [Key]
        [Required, ForeignKey("User")]
        public string UserID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Education Education { get; set; }
        public Gender Gender { get; set; }
        public int TK { get; set; }
        public int Age { get; set; }
        public FamilyStatus FamilyStatus { get; set; }
        public Work Work { get; set; }
        public int Roommates { get; set; }
        public FinancialStatus FinancialStatus { get; set; }
        
        public virtual User User { get; set; }
        public List<RoomateRelation> RoomateRelations { get; set; }
        public List<Industry> Industries { get; set; }

        public Demographic()
        {
            RoomateRelations = new List<RoomateRelation>();
            Industries = new List<Industry>();
        }
    }
}
