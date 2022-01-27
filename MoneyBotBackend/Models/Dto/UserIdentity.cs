using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Models.Dto
{
    public class UserIdentity
    {
        public int PhoneNumberPrefix { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
