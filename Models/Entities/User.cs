using System.ComponentModel.DataAnnotations;

namespace BindrAPI.Models.Entities
{
    public class User
    {
        [Key]
        public Guid userID { get; set; }
        public required string firstName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public string? passwordHash {  get; set; }
        public string? Provider { get; set; } //will store whether they logged in with password or google
        public required DateTime createdAt {  get; set; }
    }
}
