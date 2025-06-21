using BindrAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.DTOs
{
    public class FormSubmissionDTO
    {
        public Guid Id { get; set; }
        public Guid FormTemplateId { get; set; }
        public string? SubmitterEmail { get; set; }
        public required string Filename { get; set; }
        public DateTime SubmittedAt { get; set; }
        public List<FieldResponseDTO> Responses { get; set; } = new List<FieldResponseDTO>();
        public List<FileUploadDTO> Files { get; set; } = new List<FileUploadDTO>();
        public LocationInfoDTO Location { get; set; }
    }
}
