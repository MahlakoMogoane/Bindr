using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities 
{
    public class FormSubmission
    {
        [Key]public Guid formSubmissionID { get; set; }
        [ForeignKey(nameof(FormTemplate.formTemplateID))]public Guid FormTemplateId { get; set; }
        public required FormTemplate FormTemplate { get; set; }

        public string? SubmitterEmail { get; set; }
        public string? StoragePath { get; set; } // e.g., Google Drive URL
        public required string Filename { get; set; }

        public List<FieldResponse> Responses { get; set; } = new();
        public List<FileUpload> Files { get; set; } = new();
        public LocationInfo? Location { get; set; }

        public DateTime SubmittedAt { get; set; }
    }

}