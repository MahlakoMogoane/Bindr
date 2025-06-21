namespace BindrAPI.Models.DTOs
{
    public class FormTemplateDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? HeaderImageUrl { get; set; }
        public bool RequireLocation { get; set; }
        public bool RequireIdUpload { get; set; }
        public List<FormFieldDTO> Fields { get; set; } = new List<FormFieldDTO>();
        public QrCodeDTO? QrCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
