
namespace TripPlanner.Models.DTO.UserDTOs
{
    public class CreateUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        public static implicit operator User(CreateUserDTO User)
        {
            if (User == null)
                return null;

            return new User
            {
                Email = User.Email,
                FullName = User.FullName,
                PasswordHash = User.PasswordHash,
                FullAddress = User.FullAddress,
                City = User.City,
                DateOfBirth = User.DateOfBirth
            };
        }
    }
}
