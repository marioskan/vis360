using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Enumerations;

namespace VIS360.Core.Entities
{
    public class Industry
    {
        public int ID { get; set; }
        public int DemographicID { get; set; }
        public Industries Industries { get; set; }

        public virtual Demographic Demographic { get; set; }

    }
}
