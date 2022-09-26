using AutoMapper;
using Gisfpp_projects.Project.Model.Dto;

namespace Gisfpp_projects.Project.Model.Profiles
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();            
        }
    }
}
