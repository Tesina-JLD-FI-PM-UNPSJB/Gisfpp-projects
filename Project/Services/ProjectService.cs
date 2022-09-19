using Gisfpp_projects.Project.Data;
using Gisfpp_projects.Project.Model.Dto;

namespace Gisfpp_projects.Project.Services
{
    public class ProjectService
    {
        public const string MSG_PROJECT_WITHOU_TITLE = "Debe especificarle un \"Título\" al Proyecto.";
        public const string MSG_TITLE_GREATER_80 = "El \"Título\" del Proyecto no debe ser mayor a 80 caracteres.";
        public const string MSG_STATE_DISTINCT_GENERATED = "El estado del proyecto debe ser GENERATED.";
        public const string MSG_START_GREATER_EQUEL_THAN_FINISH = "La Fecha de finalizacion del proyecto debe ser posterior a la fecha de inicio.";
        public const string MSG_STAR_IS_NULL = "Debe especificarle una \"fecha de inicio\" al Proyecto.";
        public const string MSG_END_IS_NULL = "Debe especificarle una \"fecha de finalización\" al Proyecto.";
        public const string MSG_DESCRIPTION_GREATER_500 = "\"La Descripcion\" del Proyecto no debe ser mayor a 500 caracteres.";

        //private List<ProjectDTO> _dbProjects;
        private ProjectDbContext _dbContext;

        public ProjectService(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        

        public ProjectDTO CreateProject(ProjectDTO newProject)
        {
            // Argument Validations
            //ValidateProject(newProject);
            Model.Project newProjectDB = new Model.Project
            {
                Title = newProject.Title,
                Description = newProject.Description!,
                ResolutionNumber = newProject.ResolutionNumber!,
                Type = newProject.Type,
                State = newProject.State,
                Start = (DateTime)(newProject.Start is not null ? newProject.Start : DateTime.Today),
                End = ((DateTime)(newProject.End is not null ? newProject.End : DateTime.Today.AddMonths(12))),
            };
            _dbContext.projects.Add(newProjectDB);
            _dbContext.SaveChanges();
            newProject.Id = newProjectDB.Id;
            
            return newProject;
        }


        public ProjectDTO GetProjectById(int id)
        {
            var projectFind = _dbContext.projects.Single<Model.Project>(proj => proj.Id == id);
            return new ProjectDTO(projectFind.Title, projectFind.Type, projectFind.State, projectFind.Start, projectFind.End);
        }

        private void ValidateProject(ProjectDTO newProject)
        {
            if (string.IsNullOrEmpty(newProject.Title)) throw new ArgumentException(MSG_PROJECT_WITHOU_TITLE);

            if (newProject.Title.Length > 80) throw new ArgumentException(MSG_TITLE_GREATER_80);

            if (newProject.State != Model.StateProject.GENERATED) throw new ArgumentException(MSG_STATE_DISTINCT_GENERATED);

            if (newProject.Start == null) throw new ArgumentException(MSG_STAR_IS_NULL);

            if (newProject.End == null) throw new ArgumentException(MSG_END_IS_NULL);

            if (newProject.Start >= newProject.End) throw new ArgumentException(MSG_START_GREATER_EQUEL_THAN_FINISH);

            if (!string.IsNullOrEmpty(newProject.Description)
                    && newProject.Description.Length > 500) throw new ArgumentException(MSG_DESCRIPTION_GREATER_500);
        }
    }
}