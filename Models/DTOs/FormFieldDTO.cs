namespace BindrAPI.Models.DTOs
{
    public class FormFieldDTO
    {
        public Guid Id { get; set; }

        public required string Label { get; set; }
        public required string FieldType { get; set; } // "text", "date", "upload", "signature"
        public bool IsRequired { get; set; }
        public int Order { get; set; }
    }
}
