using Gisfpp_projects.Shared.Model;
using Gisfpp_projects.Shared.Repositories;

namespace Gisfpp_projects.Project.Repositories
{
    public interface IProjectRepository: IGenericRepository<Model.Project, int>
    {
        public ResultPage<Model.Project> GetPage(int pageNumber, int sizePage);
    }
}