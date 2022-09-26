using Gisfpp_projects.Project.Data;
using Gisfpp_projects.Project.Exceptions;

namespace Gisfpp_projects.Project.Repositories
{
    public class ProjectDBRepository : IProjectRepository
    {
        private readonly ProjectDbContext _dbContext;

        public ProjectDBRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public void Update(Model.Project entity)
        {
            throw new NotImplementedException();
        }
    }
}