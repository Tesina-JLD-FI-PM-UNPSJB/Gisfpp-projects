using Microsoft.EntityFrameworkCore;
using Gisfpp_projects.Project.Data;
using Gisfpp_projects.Project.Exceptions;
using Gisfpp_projects.Shared.Model;
using Gisfpp_projects.Shared.Services;

namespace Gisfpp_projects.Project.Repositories
{
    public class ProjectDBRepository : IProjectRepository
    {
        private readonly ProjectDbContext _dbContext;

        public ProjectDBRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public int Create(Model.Project entity)
        {
            _dbContext.Add(entity);

            try
            {
                _dbContext.SaveChanges();
                return entity.Id;
            }
            catch (Exception exc)
            {
                throw new ProjectRepositoryException("Error al crear proyecto.", exc);
            }

            
        }

        public void Delete(Model.Project entity)
        {
            throw new NotImplementedException();
        }

        public Model.Project? FindById(int id)
        {
            return _dbContext.projects.Find(id);
        }

        public IEnumerable<Model.Project> GetAll()
        {
            return _dbContext.projects.ToList();
        }

        public ResultPage<Model.Project> GetPage(int pageNumber, int sizePage)
        {
            var paginator = new Paginator<DbSet<Model.Project>, Model.Project, int>(_dbContext.projects, p => p.Id);

            return paginator.GetPage(pageNumber, sizePage);
        }

        public void Update(Model.Project entity)
        {
            throw new NotImplementedException();
        }
    }
}