using Microsoft.EntityFrameworkCore;

namespace Gisfpp_projects.Project.Data
{
    public class ProjectDbContext: DbContext
    {
        public DbSet<Model.Project> projects { get; set; } = null!;
        
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }
        

    }

}
