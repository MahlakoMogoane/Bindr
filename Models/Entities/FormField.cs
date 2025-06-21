using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BindrAPI.Models.Entities
{
    public class FormField
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(FormTemplate.formTemplateID))]
        public Guid FormTemplateId { get; set; }

        public required string Label { get; set; }
        public required string FieldType { get; set; } // "text", "date", "upload", "signature"
        public bool IsRequired { get; set; }
        public int Order { get; set; }
    }

}