using Gisfpp_projects.Project.Model.Dto;

namespace Gisfpp_projects.Project.Services
{
    public class ProjectService
    {
        public const string MSG_PROJECT_WITHOU_TITLE = "Debe especificarle un \"Titulo\" al Proyecto.";
        public const string MSG_TITLE_GREATER_80 = "El \"Titulo\" del Proyecto no debe ser mayor a 80 caracteres.";
        public const string MSG_STATE_DISTINCT_GENERATED = "El estado del proyecto debe ser GENERATED.";
        public const string MSG_START_GREATER_EQUEL_THAN_FINISH = "La Fecha de finalizacion del proyecto debe ser posterior a la fecha de inicio.";
        public const string MSG_STAR_IS_NULL = "Debe especificarle una \"fecha de inicio\" al Proyecto.";
        public const string MSG_END_IS_NULL = "Debe especificarle una \"fecha de finalización\" al Proyecto.";
        public const string MSG_DESCRIPTION_GREATER_500 = "\"La Descripcion\" del Proyecto no debe ser mayor a 500 caracteres.";
        
        private List<ProjectDTO> _dbProjects;

        public ProjectService()
        {
            _dbProjects = new List<ProjectDTO>();
        }

        public ProjectDTO CreateProject(ProjectDTO newProject)
        {
            // Argument Validations
            if (string.IsNullOrEmpty(newProject.Title)) throw new ArgumentException(MSG_PROJECT_WITHOU_TITLE);

            if (newProject.Title.Length > 80) throw new ArgumentException(MSG_TITLE_GREATER_80);

            if (newProject.State != Model.StateProject.GENERATED) throw new ArgumentException(MSG_STATE_DISTINCT_GENERATED);

            if (newProject.Start == null) throw new ArgumentException(MSG_STAR_IS_NULL);

            if (newProject.End == null) throw new ArgumentException(MSG_END_IS_NULL); 

            if (newProject.Start >= newProject.End) throw new ArgumentException(MSG_START_GREATER_EQUEL_THAN_FINISH);

            if (!string.IsNullOrEmpty(newProject.Description) 
                    && newProject.Description.Length > 500) throw new ArgumentException(MSG_DESCRIPTION_GREATER_500);

            Guid newProjectId = Guid.NewGuid();

            ProjectDTO result = newProject with { Id = newProjectId };
            _dbProjects.Add(result);

            return result;
        }

        public ProjectDTO GetProjectById(Guid? id)
        {
            return _dbProjects.Find(proj => proj.Id == id);
        }
    }
}