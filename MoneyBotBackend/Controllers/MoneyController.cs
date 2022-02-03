using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBotBackend.DbContext;
using MoneyBotBackend.Models;
using MoneyBotBackend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyBotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyController : ControllerBase
    {
        private MoneyBotContext _context;

        public MoneyController(MoneyBotContext context)
        {
            _context = context;
        }

        [HttpPost("add{userId}")]
        public async Task<ActionResult>  AddMoneyOperation([FromQuery] int userId, [FromBody] MoneyOperation moneyOperation)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            Money money = new Money()
            {
                Sum = moneyOperation.Sum,
                Operation = moneyOperation.Operation,
                DateTime = moneyOperation.DateTime,
                User = user
            };

            _context.Add(money);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
