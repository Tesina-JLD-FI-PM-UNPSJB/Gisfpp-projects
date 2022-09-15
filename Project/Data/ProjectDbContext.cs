using Microsoft.EntityFrameworkCore;

namespace Gisfpp_projects.Project.Data
{
    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Model.Project> projects { get; set; }
        
    }

}
