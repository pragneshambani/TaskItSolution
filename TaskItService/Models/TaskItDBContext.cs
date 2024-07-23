using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskItService.Models
{
    public partial class TaskItDBContext : DbContext
    {
        //public TaskItDBContext() : base() { }
        public TaskItDBContext(DbContextOptions
        <TaskItDBContext> options)
            : base(options)
        {}

        public virtual DbSet<Models.Task> Task { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>(entity => {
                entity.HasKey(k => k.TaskId);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
