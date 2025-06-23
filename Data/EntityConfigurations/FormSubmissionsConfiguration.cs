using BindrAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FormSubmissionConfiguration : IEntityTypeConfiguration<FormSubmission>
{
    public void Configure(EntityTypeBuilder<FormSubmission> builder)
    {
        builder.HasKey(f => f.formSubmissionID);
        builder.Property(f => f.Filename).IsRequired().HasMaxLength(200);
        builder.Property(f => f.SubmittedAt).IsRequired();

        builder.HasOne(f => f.FormTemplate)
               .WithMany()
               .HasForeignKey(f => f.FormTemplateId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Responses)
               .WithOne()
               .HasForeignKey(r => r.FormSubmissionId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Files)
               .WithOne()
               .HasForeignKey(f => f.FormSubmissionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
