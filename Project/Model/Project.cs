using System.ComponentModel.DataAnnotations.Schema;

namespace Gisfpp_projects.Project.Model
{
    [Table("PROJECTS")]
    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string ResolutionNumber { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public TypeProject Type { get; set; }  
        public StateProject State { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Detail { get; set; } = null!;
    }
}
