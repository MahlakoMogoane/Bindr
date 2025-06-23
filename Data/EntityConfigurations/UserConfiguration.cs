using BindrAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.userID);
        builder.Property(u => u.email).IsRequired().HasMaxLength(256);
        builder.Property(u => u.passwordHash).IsRequired().HasMaxLength(256);
        builder.Property(u => u.Provider).IsRequired().HasMaxLength(50);
        builder.Property(u => u.firstName).HasMaxLength(100);
        builder.Property(u => u.lastName).HasMaxLength(100);
        builder.Property(u => u.createdAt).IsRequired();

        builder.HasIndex(u => u.email).IsUnique();
    }
}
