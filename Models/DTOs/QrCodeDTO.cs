namespace BindrAPI.Models.DTOs
{
    public class QrCodeDTO
    {
        public required string QrCodeUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
