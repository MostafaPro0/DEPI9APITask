using Microsoft.EntityFrameworkCore;

namespace DEPI9APITask.DAL.Contexts;

public class DEPI9APITaskContext : DbContext
{
    public DEPI9APITaskContext(DbContextOptions<DEPI9APITaskContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
