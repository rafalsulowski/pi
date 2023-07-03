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

        private readonly IUserService _UserService;
        private readonly IBillService _BillService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserService userService, IPasswordHasher<User> passwordHasher, IBillService billService)
        {
            _UserService = userService;
            _passwordHasher = passwordHasher;
            _BillService = billService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<UserDTO>>>> Get()
        {
            var response = await _UserService.GetUsersAsync();
            List<UserDTO> res = response.Data.Select(u => (UserDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithCheckLists")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithCheckLists(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "CheckLists");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithOrganizerTours")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithOrganizerTours(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "OrganizerTours");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithParticipantTours")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithParticipantTours(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "ParticipantTours");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithParticipantBudgets")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithParticipantBudgets(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "ParticipantBudgets");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithQuestionnaires")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithQuestionnaires(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Questionnaires");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithQuestionnaireVotes")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithQuestionnaireVotes(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "QuestionnaireVotes");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithParticipantGroups")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithParticipantGroups(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "ParticipantGroups");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithRoutes")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithRoutes(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Routes");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithBills/{id}")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBills(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Bills");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithMessages")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithMessages(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Messages");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithBillSettle")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBillSettle(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "BillSettle");
            UserDTO res = response.Data;
            return Ok(res);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> Get(int id)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == id);
            UserDTO res = response.Data;
            return Ok(res);
        }

        // GET api/<ValuesController>/xyz@wp.pl
        [HttpGet("email")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> Get(string email)
        {
            var response = await _UserService.GetUserAsync(u => u.Email == email);
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<RepositoryResponse<bool>>> Create([FromBody] CreateUserDTO user)
        {
            var userResponse = await _UserService.GetUserAsync(u => u.Email == user.Email);
            if (userResponse.Data != null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = "Użytkownik z tym e-mail'em istnieje" };
            }

            User newUser = user;

            var hashed = _passwordHasher.HashPassword(newUser, user.PasswordHash);
            newUser.PasswordHash = hashed;
            var response = await _UserService.CreateUser(newUser);
            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Put(int id, [FromBody] CreateUserDTO user)
        {
            var userResponse = await _UserService.GetUserAsync(u => u.Id == id);
            if (userResponse.Data == null)
            {
                return new RepositoryResponse<bool> { Success = false, Message = $"Nie istnieje uzytkownik o id = {id}" };
            }

            User newUser = userResponse.Data;
            newUser.Name = user.Name;
            newUser.Surname = user.Surname;
            newUser.Email = user.Email;
            newUser.Address = user.Address;
            newUser.DateOfBirth = user.DateOfBirth;
            newUser.PasswordHash = user.PasswordHash;
            newUser.Id = id;

            var response = await _UserService.UpdateUser(newUser);
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RepositoryResponse<bool>>> Delete(int id)
        {
            var response = await _UserService.DeleteUser(new User() { Id = id });
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
            var userResponse = await _UserService.GetUserAsync(u => u.Email == loginUser.Email);

            if (userResponse.Data == null)
                return Forbid("No user with this email exists");

            var user = userResponse.Data;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.PasswordHash);
            if (result == PasswordVerificationResult.Failed)
                return Forbid("Invalid credentials");

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
