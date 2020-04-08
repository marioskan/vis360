using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS360.Core.Entities
{
    public class HeartDisease
    {
        public int ID { get; set; }
        public int CovidStatusID { get; set; }
        public Enumerations.HeartDiseaseEnum HeartDiseases { get; set; }

        public virtual CovidStatus CovidStatus { get; set; }
    }
}

