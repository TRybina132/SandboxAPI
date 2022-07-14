using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PassportConfiguration
        : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder
                .HasKey(passport => passport.UserId);

            builder
                .Property(passport => passport.SerialNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(passport => passport.DateOfIssue)
                .IsRequired()
                .HasColumnType("DATE");

            builder
                .HasOne(passport => passport.User)
                .WithOne(user => user.Passport)
                .HasForeignKey<Passport>(passport => passport.UserId);

            builder.ToTable("Passports");
        }
    }
}
