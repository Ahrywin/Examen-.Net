namespace Test.DTOs
{
    public class AllUserbyStringDTO
    {
        public Guid Id { get; set; }

        public string? DisplayName { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool? EmailVerified { get; set; }

        public bool? PhoneVerified { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? LastLogin { get; set; }


    }
}
