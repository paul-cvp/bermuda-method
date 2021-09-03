using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bermuda.Model
{
    public enum UserRole {
        DataScientist = 0,
        Developer = 1,
        DomainExpert = 2
    }
    public class User
    {
        public UserRole Role { get; set; }

        public string UserName { get; set; }

        public string[] Password { get; set; }
    }
}
