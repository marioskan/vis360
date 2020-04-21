using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VIS360.Core.Entities
{
    public class UserInfo
    {
        [Key]
        [Required,ForeignKey("User")]
        public string UserID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNumber { get; set; }

        public virtual User User { get; set; }

        
    }
}
