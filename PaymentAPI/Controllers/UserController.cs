using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PaymentDetailContext _context;

        public UserController(PaymentDetailContext context)
        {
            _context = context;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj== null)
            {
                return BadRequest();
            }
            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email== userObj.Email && x.Password == userObj.Password);
            if(user == null)
            {
                return NotFound(new {Message = "user not found"});
            }

            return Ok(new { Message = "Login success" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User userObj)
        {
            if(userObj== null)
            {
                return BadRequest();
            }
            await _context.Users.AddAsync(userObj);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered"
            });
          
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile(string email)
        {
            // Retrieve user details based on email
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            // Return user profile details
            return Ok(user);
        }

    }

}
