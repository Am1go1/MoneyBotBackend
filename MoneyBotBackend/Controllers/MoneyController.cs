using AutoMapper;
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
        private IMapper _mapper;

        public MoneyController(MoneyBotContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add/{userId}")]
        public async Task<ActionResult>  AddMoneyOperation([FromRoute] int userId, [FromBody] MoneyOperation moneyOperation)
        {           
            Money money = new Money()
            {
                Sum = moneyOperation.Sum,
                Operation = moneyOperation.Operation.ToLower(),
                DateTime = DateTime.Now,
                UserId = userId
            };

            _context.Add(money);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<MoneyOperation>>> GetMoneyOperation(int userId)
        {
            bool isExistUser = await _context.Users.AnyAsync(h => h.Id == userId);

            if (isExistUser) return NotFound();

            List<Money> operations = await _context.Moneys.AsNoTracking().Where(h => h.UserId == userId).ToListAsync();

            if (operations == null) return NotFound();

            List<MoneyOperation> moneyOperations = new List<MoneyOperation>();

            for (int i = 0; 1 <operations.Count; i++) 
            {
                moneyOperations.Add(_mapper.Map<MoneyOperation>(operations[i])); 
            }



            return moneyOperations;
        }

        [HttpGet("{userId}/{skipCount}/{countMoneyOperation}")]
        public async Task<ActionResult<List<Money>>> GetNewOperation(int userId, int skipCount, int countMoneyOperation)
        {
            bool isExistUser = await _context.Users.AnyAsync(h => h.Id == userId);

            if (isExistUser) return NotFound();

            List<Money> operations = await _context.Moneys.AsNoTracking().Where(h => h.UserId == userId).Skip(skipCount).Take(countMoneyOperation).ToListAsync();

            if (operations == null) return NotFound();

            return operations;
        }

    }
}
