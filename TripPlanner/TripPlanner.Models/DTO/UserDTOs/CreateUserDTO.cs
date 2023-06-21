
namespace TripPlanner.Models.DTO.UserDTOs
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public static implicit operator User(CreateUserDTO User)
        {
            if (User == null)
                return null;

            return new User
            {
                Email = User.Email,
                Name = User.Name,
                Surname = User.Surname,
                PasswordHash = User.PasswordHash,
                Address = User.Address,
                DateOfBirth = User.DateOfBirth
            };
        }
    }
}
