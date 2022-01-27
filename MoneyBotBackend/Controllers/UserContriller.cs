using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBotBackend.DbContext;
using MoneyBotBackend.Models;
using MoneyBotBackend.Models.Dto;

namespace MoneyBotBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContriller : ControllerBase
    {
        public MoneyBotContext _context;

        public UserContriller(MoneyBotContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task <ActionResult> Regirter(UserIdentity userIdentity)
        {
            User user = new User() 
            { 
                PhoneNumberPrefix = userIdentity.PhoneNumberPrefix,
                PhoneNumber = userIdentity.PhoneNumber,
                Password = userIdentity.Password
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("auth")]
        public async Task<ActionResult> Login(UserIdentity userIdentity)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u =>
                u.PhoneNumberPrefix == userIdentity.PhoneNumberPrefix &&
                u.PhoneNumber == userIdentity.PhoneNumber &&
                u.Password == userIdentity.Password);

            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
