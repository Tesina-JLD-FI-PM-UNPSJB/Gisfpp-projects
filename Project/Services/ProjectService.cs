using AutoMapper;
using Gisfpp_projects.Project.Model.Dto;
using Gisfpp_projects.Project.Repositories;
using Gisfpp_projects.Shared;
using System.ComponentModel.DataAnnotations;

namespace Gisfpp_projects.Project.Services
{
    public class ProjectService
    {

        private readonly IProjectRepository _repo;

        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        

        public ProjectDTO CreateProject(ProjectDTO newProject)
        {
            Model.Project newProjectDB = _mapper.Map<Model.Project>(newProject);
            newProjectDB.State = Model.StateProject.GENERATED;

            ValidateProject(newProjectDB);

            newProject.Id = _repo.Create(newProjectDB);

            return newProject;
        }

        public ProjectDTO? GetProjectById(int id)
        {
            var projectFind = _repo.FindById(id);
            var result = projectFind != null 
                        ? _mapper.Map<ProjectDTO>(projectFind)
                        : null;
            
            return result;
        }

        public IEnumerable<ProjectDTO> GetAllProjects() {
            var result = _repo.GetAll();
            return _mapper.Map<IEnumerable<ProjectDTO>>(result);             
        }

        private void ValidateProject(Model.Project newProjectDB)
        {
            ValidationContext validationContext = new ValidationContext(newProjectDB);
            
            #region Validar
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(newProjectDB, validationContext, validationResults, true);
            if ( !isValid )
            {
                throw new ModelInvalidException(validationResults);
            }
            #endregion
        }
    }
}