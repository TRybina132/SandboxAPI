using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class UserAchievementConfiguration : IEntityTypeConfiguration<UserAchievement>
    {
        public void Configure(EntityTypeBuilder<UserAchievement> builder)
        {
            builder.HasKey(ua => new
            {
                ua.AchievementId,
                ua.UserId
            });

            builder.HasOne<User>(ua => ua.User)
                .WithMany(user => user.UserAchievements)
                .HasForeignKey(ua => ua.UserId);

            builder.HasOne<Achievement>(ua => ua.Achievement)
                .WithMany(achievement => achievement.UserAchievements)
                .HasForeignKey(ua => ua.AchievementId);

            builder.ToTable("UserAchievements");
        }
    }
}
