using Gisfpp_projects.Project.Model.Dto;
using Gisfpp_projects.Project.Services;
using Gisfpp_projects.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Gisfpp_projects.Project.Controllers
{
    public class ProjectsController : ProjectBaseController
    {
        private ProjectService _service;

        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjectDTO> CreateProject(ProjectDTO request) {
            ProjectDTO result = _service.CreateProject(request);
            return CreatedAtAction(null, null, null, result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetAllProject()
        {
            var result = _service.GetAllProjects();
            return Ok(result);
        }

        [HttpGet("{id}")]        
        public ActionResult<ProjectDTO> GetProject( int id)
        {
            var result = _service.GetProjectById(id);
            if (result == null) return NotFound();
                
            return Ok(result);
        }
    }
}
