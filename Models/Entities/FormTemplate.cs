using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities
{
    public class FormTemplate
    {
        [Key]
        public Guid formTemplateID { get; set; }

        [StringLength(50)]
        public required string Title { get; set; }

        [StringLength(255)]
        public required string description { get; set; }

        [ForeignKey(nameof(User.userID))]
        public Guid ownerID {  get; set; }
        public required User Owner { get; set; }

        public List<FormField> Fields { get; set; } = new();
        public QrCode? QrCode { get; set; }

        public string? headerImageURL { get; set; }
        public bool requireLocation { get; set; }
        public bool requireSignature { get; set; }
        public required DateTime createdAt { get; set; }
        public required DateTime updatedAt {  get; set; }

    }
}