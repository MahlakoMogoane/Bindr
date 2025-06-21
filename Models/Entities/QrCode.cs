using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities
{
    public class QrCode
    {
        [Key]public Guid codeID { get; set; }

        [ForeignKey(nameof(FormTemplate.formTemplateID))]public Guid FormTemplateId { get; set; }
        public required string QrCodeUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
