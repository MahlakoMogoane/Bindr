using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities
{
    public class FieldResponse
    {
        [Key]public Guid responseID { get; set; }

        [ForeignKey(nameof(FormSubmission.formSubmissionID))]public Guid FormSubmissionId { get; set; }
        public Guid FormFieldId { get; set; }

        public required string Response { get; set; }
    }
}
