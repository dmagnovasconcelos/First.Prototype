using First.Prototype.Access.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First.Prototype.Access.Infrastructure.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users", "public");

      builder.HasKey(e => e.Id);

      builder.Property(e => e.Id)
          .IsRequired()
          .HasColumnName("user_id");

      builder.Property(e => e.Password)
          .IsRequired()
          .HasColumnName("password")
          .HasMaxLength(20);

      builder.Property(e => e.Email)
          .IsRequired()
          .HasColumnName("email")
          .HasMaxLength(100);

      builder.Property(e => e.Active)
          .IsRequired()
          .HasColumnName("active");

      builder.Property(e => e.RedefinePassword)
          .IsRequired()
          .HasColumnName("redefine_password");

      builder.Property(e => e.ValidationToken)
          .HasColumnName("validation_token");
    }
  }
}