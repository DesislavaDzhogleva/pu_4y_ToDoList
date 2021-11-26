using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Models;

namespace ToDoList.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UsersTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTask>(entity => {
                entity.HasOne(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTask>(entity => {
                entity.HasOne(ut => ut.Task)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserTask>().ToTable("UsersTasks");
        }
    }
}
