using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskItService.Models
{
    //public partial class TaskItDBContext : DbContext
    public partial class TaskItDBContext : IdentityDbContext<User>
    {
        //public TaskItDBContext() : base() { }
        public TaskItDBContext(DbContextOptions
        <TaskItDBContext> options)
            : base(options)
        {}

        public virtual DbSet<Models.Task> Task { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Task>(entity => {
                entity.HasKey(k => k.TaskId);
            });

            //modelBuilder.Entity<Models.User>().Property(u => u.Initials).HasMaxLength(25);
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
