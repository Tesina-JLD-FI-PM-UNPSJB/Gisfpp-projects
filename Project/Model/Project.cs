using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gisfpp_projects.Project.Model
{
    [Table("PROJECTS")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Column("code")]
        [MaxLength(20)]
        public string? Code { get; set; }
        [Column("resolution_number")]
        [MaxLength(20)]
        public string? ResolutionNumber { get; set; } = null!;
        [Column("title")]
        [Required(ErrorMessage = "Debe especificarle un \"Título\" al Proyecto.")]
        [StringLength(80, ErrorMessage = "El \"Título\" del Proyecto no debe superar los 80 caractéres.")]
        public string Title { get; set; } = null!;
        [Column("description")]
        [MaxLength(500)]
        public string? Description { get; set; }
        [Column("type")]
        public TypeProject Type { get; set; }  
        [Column("state")]
        public StateProject State { get; set; }
        [Column("start")]
        public DateTime Start { get; set; }
        [Column("end")]
        public DateTime End { get; set; }
        [Column("detail")]        
        public string? Detail { get; set; }
    }
}
