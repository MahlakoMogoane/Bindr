using BindrAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FormTemplateConfiguration : IEntityTypeConfiguration<FormTemplate>
{
    public void Configure(EntityTypeBuilder<FormTemplate> builder)
    {
        builder.HasKey(f => f.formTemplateID);
        builder.Property(f => f.Title).IsRequired().HasMaxLength(200);
        builder.Property(f => f.createdAt).IsRequired();
        builder.Property(f => f.updatedAt).IsRequired();

        builder.HasOne(f => f.Owner)
               .WithMany()
               .HasForeignKey(f => f.ownerID)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
