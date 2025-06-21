namespace BindrAPI.Models.DTOs
{
    public class UserDTO
    {
        public Guid userID { get; set; }
        public required string email { get; set; }
        public required string firstName { get; set; }
        public required string lastname {  get; set; }
        public required string passwordHash { get; set; }
        public DateTime createdAt { get; set; }
    }
}
