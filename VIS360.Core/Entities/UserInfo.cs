using System;
using System.Collections.Generic;
using System.Text;

namespace VIS360.Core.Entities
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public virtual User User { get; set; } 
    }
}
