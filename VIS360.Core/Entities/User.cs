using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VIS360.Core.Entities
{
    public class User
    {
        [Key]
        public string Ud { get; set; }

        public string Email { get; set; }
        public string Provider { get; set; }


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
