using Microsoft.IdentityModel.Tokens;
using TripPlanner.Models;
using TripPlanner.Services.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripPlanner.Models.DTO.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.BillModels;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models.TourModels;
using TripPlanner.Services.TourService;
using TripPlanner.Models.Models.UserModels;

namespace TripPlanner.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _UserService;
        private readonly ITourService _TourService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(IUserService userService, IPasswordHasher<User> passwordHasher, ITourService tourService)
        {
            _UserService = userService;
            _passwordHasher = passwordHasher;
            _TourService = tourService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<RepositoryResponse<List<UserDTO>>>> Get()
        {
            var response = await _UserService.GetUsersAsync();
            List<UserDTO> res = response.Data.Select(u => (UserDTO)u).ToList();
            return Ok(res);
        }

        [HttpGet("GetToursOfUser/{userId}")]
        public async Task<ActionResult<RepositoryResponse<List<TourDTO>>>> GetToursOfUser(int userId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == userId, "ParticipantTours");
            if (response.Data == null)
            {
                return new RepositoryResponse<List<TourDTO>> { Data = null, Success = false, Message = "Użytkownik z tym id nie istnieje" };
            }

            UserDTO res = response.Data;
            List<TourDTO> tours = new List<TourDTO>();

            if(res.ParticipantTours.Count == 0)
                return Ok(tours);

            foreach(ParticipantTour participant in res.ParticipantTours)
            {
                var resp = await _TourService.GetTourAsync(u => u.Id == participant.TourId);
                if (resp.Data is not null)
                    tours.Add(resp.Data);
            }

            return Ok(tours);
        }

        [HttpGet("{UserId}/GetWithCheckLists")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithCheckLists(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "CheckLists");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithShares")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithShares(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Shares");
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

        [HttpGet("{UserId}/GetWithQuestionnaireVotes")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithQuestionnaireVotes(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "QuestionnaireVotes");
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

        [HttpGet("{UserId}/GetWithMessages")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithMessages(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "Messages");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithBillContributors")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBillContributors(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "BillContributors");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithBillPayed")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithBillPayed(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "BillsPayed");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithTransfersSender")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithTransfersSender(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "TransfersSender");
            UserDTO res = response.Data;
            return Ok(res);
        }

        [HttpGet("{UserId}/GetWithTransfersRecipient")]
        public async Task<ActionResult<RepositoryResponse<UserDTO>>> GetWithTransfersRecipient(int UserId)
        {
            var response = await _UserService.GetUserAsync(u => u.Id == UserId, "TransfersRecipient");
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
            newUser.Email = user.Email;
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
        public async Task<ActionResult> Login([FromBody] LoginDTO loginUser)
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
                new Claim(ClaimTypes.Name, user.FullName.ToString()),
                new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString()),
                new Claim(ClaimTypes.StateOrProvince, user.FullAddress.ToString()),
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
