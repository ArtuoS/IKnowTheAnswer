using IKnowTheAnswer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IKnowTheAnswer.Infrastructure.Repositories.DatabaseContext
{
    public class IKnowTheAnswerDbContext : DbContext
    {
        public IKnowTheAnswerDbContext(DbContextOptions<IKnowTheAnswerDbContext> opt) : base(opt)
        { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionLogger> QuestionLoggers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}