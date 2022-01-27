using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Models
{
    public class User
    {
        public int Id{ get; set; }
        public int PhoneNumberPrefix { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

        public List<Money> Moneys { get; set; }
    }
}
