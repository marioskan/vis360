using System;
using System.Collections.Generic;
using System.Text;

namespace VIS360.Core.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual Demographic Demographic { get; set; }
        public List<CovidStatus> CovidStatuses { get; set; }
        public List<DiseaseStatement> DiseaseStatements { get; set; }
        public List<OtherMember> OtherMembers { get; set; }

        public User()
        {
            CovidStatuses = new List<CovidStatus>();
            DiseaseStatements = new List<DiseaseStatement>();
            OtherMembers = new List<OtherMember>();
        }
    }
}
