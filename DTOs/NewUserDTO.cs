using Test.Data.Enums;

namespace Test.DTOs
{
    public class NewUserDTO
    {

        public string? Token { get; set; }

        public string Password { get; set; } = null!;

        public DateTime? Brithday { get; set; }

        public string? Name { get; set; }

        public string Name2 { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? DisplayName { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string PhotoUrl { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public UserRolEnum  UserRol { get; set; }

        public bool? EmailVerified { get; set; }

        public bool? PhoneVerified { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? LastLogin { get; set; }

        public string? Origin { get; set; }

        public Guid? CreatedBy { get; set; }
    }
}
