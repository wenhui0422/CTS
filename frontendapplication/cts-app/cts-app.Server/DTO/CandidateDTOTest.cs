namespace cts_app.Server.DTO
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public string? FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ZipCode { get; set; }
    }
}
