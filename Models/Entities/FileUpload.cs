using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities
{
    public class FileUpload
    {
        [Key]public Guid fileUploadID { get; set; }

        [ForeignKey(nameof(FormSubmission.formSubmissionID))]public Guid FormSubmissionId { get; set; }
        public required string FileType { get; set; } // "id-upload", "signature", etc.
        public required string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
