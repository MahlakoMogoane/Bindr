namespace BindrAPI.Models.DTOs
{
    public class FileUploadDTO
    {
        public Guid Id { get; set; }
        public required string FileType { get; set; }
        public required string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
