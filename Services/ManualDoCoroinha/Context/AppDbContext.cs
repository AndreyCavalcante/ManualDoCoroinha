using ManualDoCoroinha.Models;
using ManualDoCoroinha.Models.Alternatives;
using ManualDoCoroinha.Models.Certificates;
using ManualDoCoroinha.Models.Lessons;
using ManualDoCoroinha.Models.Modules;
using ManualDoCoroinha.Models.Prayers;
using ManualDoCoroinha.Models.Questions;
using ManualDoCoroinha.Models.Quizzes;
using ManualDoCoroinha.Models.UserCertificates;
using ManualDoCoroinha.Models.UserFavoritePrayers;
using ManualDoCoroinha.Models.UserModules;
using ManualDoCoroinha.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManualDoCoroinha.Context;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Module> Modules => Set<Module>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<Quiz> Quizzes => Set<Quiz>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Alternative> Alternatives => Set<Alternative>();
    public DbSet<Prayer> Prayers => Set<Prayer>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<UserModule> UserModules => Set<UserModule>();
    public DbSet<UserFavoritePrayer> UserFavoritePrayers => Set<UserFavoritePrayer>();
    public DbSet<UserCertificate> UserCertificates => Set<UserCertificate>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Module>()
        .HasOne(m => m.Quiz)
        .WithOne(q => q.Module)
        .HasForeignKey<Quiz>(q => q.ModuleId);

        builder.Entity<Lesson>()
            .HasOne(l => l.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(l => l.ModuleId);

        builder.Entity<Question>()
            .HasOne(q => q.Quiz)
            .WithMany(qz => qz.Questions)
            .HasForeignKey(q => q.QuizId);

        builder.Entity<Alternative>()
            .HasOne(a => a.Question)
            .WithMany(q => q.Alternatives)
            .HasForeignKey(a => a.QuestionId);

        builder.Entity<UserModule>()
            .HasOne(um => um.User)
            .WithMany(u => u.UserModules)
            .HasForeignKey(um => um.UserId);

        builder.Entity<UserModule>()
            .HasOne(um => um.Module)
            .WithMany()
            .HasForeignKey(um => um.ModuleId);

        builder.Entity<UserCertificate>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCertificates)
            .HasForeignKey(uc => uc.UserId);

        builder.Entity<UserFavoritePrayer>()
            .HasOne(fp => fp.User)
            .WithMany(u => u.FavoritePrayers)
            .HasForeignKey(fp => fp.UserId);
    }
}
