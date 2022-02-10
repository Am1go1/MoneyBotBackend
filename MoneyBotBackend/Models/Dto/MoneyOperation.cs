using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Models.Dto
{
    public class MoneyOperation
    {
        public int? Id  { get; set; }
        public double Sum { get; set; }
        public string Operation { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
