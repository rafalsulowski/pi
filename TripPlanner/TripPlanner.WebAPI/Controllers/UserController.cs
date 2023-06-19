using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TripPlanner.Models.Models;
using TripPlanner.Models.DTO;
using TripPlanner.Services;
using TripPlanner.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripPlanner.WebAPI;
using TripPlanner.Services.BillService;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IBillService _BillService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserService userService, IPasswordHasher<User> passwordHasher, IBillService billService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _BillService = billService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<User>>>> Get()
        {
            var response = await _userService.GetUsersAsync();
            return Ok(response.Data);
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<User>>> Get(int id)
        {
            var response = await _userService.GetUserAsync(u => u.Id == id);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        // GET api/<ValuesController>/xyz@wp.pl
        [HttpGet("email")]
        public async Task<ActionResult<RepositoryResponse<User>>> Get(string email)
        {
            var response = await _userService.GetUserAsync(u => u.Email == email);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetPlaceWithCommentsAndLikes/{id}")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBillSettle(int id)
        {
            var response = await _userService.GetUserAsync(u => u.Id == id, "BillSettle");
            if (response.Success)
            {
                return Ok(response.Data.MapToDTO());
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<User>>> Post([FromBody] UserDTO user)
        {
            var userResponse = await _userService.GetUserAsync(u => u.Email == user.Email);
            if (userResponse.Data != null)
            {
                return new RepositoryResponse<User> { Success = false, Message = "User with this email already exists" };
            }
            userResponse = await _userService.GetUserAsync(u => u.Username == user.Username);
            if (userResponse.Data != null)
            {
                return new RepositoryResponse<User> { Success = false, Message = "User with this username already exists" };
            }

            User newUser = new User
            {
                Email = user.Email,
                Username = user.Username,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth
            };
            var hashed = _passwordHasher.HashPassword(newUser, user.PasswordHash);
            newUser.PasswordHash = hashed;
            var response = await _userService.CreateUser(newUser);
            return Ok(response.Data);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<User>>> Put([FromBody] User user)
        {
            var response = await _userService.UpdateUser(user);
            return Ok(response.Data);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _userService.DeleteUser(new User() { Id = id });
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Data);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserDTO loginUser)
        {
            var userResponse = await _userService.GetUserAsync(u => u.Email == loginUser.Email);

            if (userResponse.Data == null)
                return Forbid("No user with this email exists");

            var user = userResponse.Data;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.PasswordHash);
            if (result == PasswordVerificationResult.Failed)
                return Forbid("Invalid password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(AuthenticationSettings.JwtExpiresDays);

            var token = new JwtSecurityToken(AuthenticationSettings.Issuer,
                AuthenticationSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            string tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}
