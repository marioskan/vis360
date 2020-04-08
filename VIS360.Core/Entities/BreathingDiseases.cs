using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class BreathingDiseases
    {
        public int ID { get; set; }
        public int CovidStatusID { get; set; }
        public BreathingDiseasesEnum BreathingDisease { get; set; }

        public virtual CovidStatus CovidStatus { get; set; }
    }
}

