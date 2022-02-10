using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Models
{
    public class Money
    {
        public int Id { get; set; }
        public double Sum { get; set; }
        public string Operation { get; set; }
        public DateTime? DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
