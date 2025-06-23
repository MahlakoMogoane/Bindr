using BindrAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
{
    public void Configure(EntityTypeBuilder<FormField> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Label).IsRequired().HasMaxLength(100);
        builder.Property(f => f.FieldType).IsRequired().HasMaxLength(50);
        builder.Property(f => f.Order).IsRequired();
    }
}
