using Microsoft.IdentityModel.Tokens;
using TripPlanner.Models;
using TripPlanner.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripPlanner.Services.BillService;
using TripPlanner.Models.DTO.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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
        public async Task<ActionResult<RepositoryResponse<List<UserDTO>>>> Get()
        {
            var response = await _userService.GetUsersAsync();
            List<UserDTO> res = response.Data.Select(u => (UserDTO)u).ToList();
            return Ok(res);
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> Get(int id)
        {
            var response = await _userService.GetUserAsync(u => u.Id == id);
            UserDTO res = response.Data;
            return Ok(res);
        }

        // GET api/<ValuesController>/xyz@wp.pl
        [HttpGet("email")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> Get(string email)
        {
            var response = await _userService.GetUserAsync(u => u.Email == email);
            UserDTO res = response.Data;
            return Ok(res);
        }

        // GET api/<ValuesController>/5
        [HttpGet("GetUserWithBillSettle/{id}")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBillSettle(int id)
        {
            var response = await _userService.GetUserAsync(u => u.Id == id, "BillSettle");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateUserDTO user)
        {
            var userResponse = await _userService.GetUserAsync(u => u.Email == user.Email);
            if (userResponse.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = "Użytkownik z tym e-mail'em istnieje" };
            }

            User newUser = user;

            var hashed = _passwordHasher.HashPassword(newUser, user.PasswordHash);
            newUser.PasswordHash = hashed;
            var response = await _userService.CreateUser(newUser);
            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Put([FromBody] UserDTO user)
        {
            User newUser = user;
            var response = await _userService.UpdateUser(newUser);
            return Ok(response.Data);
        }

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
                new Claim(ClaimTypes.Name, user.Name.ToString()),
                new Claim(ClaimTypes.Surname, user.Surname.ToString()),
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
