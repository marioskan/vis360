using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class CovidStatus 
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? OtherMemberID { get; set; }
        public bool BloodPressure { get; set; }
        public bool Diabetes { get; set; }
        public bool Smoker { get; set; }
        public bool Overweight { get; set; }
        public List<HeartDisease> HeartDiseases { get; set; }
        public List<BreathingDiseases> BreathingDiseases { get; set; }

        public virtual User User { get; set; }
        public virtual OtherMember OtherMember { get; set; }

    }
}

