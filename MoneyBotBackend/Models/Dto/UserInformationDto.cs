using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Models.Dto
{
    public class UserInformationDto
    {
        public int Id { get; set; }
        public int PhoneNumberPrefix { get; set; }
        public long PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
