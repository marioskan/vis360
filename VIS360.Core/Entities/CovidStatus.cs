﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class CovidStatus : OtherMember
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public CovidMember  CovidMember { get; set; }
        public HeartDisease HeartDisease { get; set; }
        public BreathingDiseases BreathingDiseases { get; set; }
        public bool BloodPressure { get; set; }
        public bool Diabetes { get; set; }
        public bool Smoker { get; set; }
        public bool Overweight { get; set; }


        public virtual User User { get; set; }
    }
}

