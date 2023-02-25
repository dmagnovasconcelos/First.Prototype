using First.Prototype.Administrator.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First.Prototype.Administrator.Infrastructure.Mappings
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("user", "public");

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

      builder.Property(e => e.FirstName)
          .IsRequired()
          .HasColumnName("first_name")
          .HasMaxLength(50);

      builder.Property(e => e.LastName)
          .IsRequired()
          .HasColumnName("last_name")
          .HasMaxLength(50);

      builder.Property(e => e.NickName)
          .HasColumnName("nick_name")
          .HasMaxLength(50);

      builder.Property(e => e.Active)
          .IsRequired()
          .HasColumnName("active");

      builder.Property(e => e.BirthDate)
          .IsRequired()
          .HasColumnName("birth_date");

      builder.Property(e => e.RedefinePassword)
          .IsRequired()
          .HasColumnName("redefine_password");

      builder.Property(e => e.ValidationToken)
          .HasColumnName("validation_token");
    }
  }
}