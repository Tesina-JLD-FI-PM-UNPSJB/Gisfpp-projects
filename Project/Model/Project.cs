using Gisfpp_projects.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gisfpp_projects.Project.Model
{
    [Table("PROJECTS")]
    public class Project: IValidatableObject
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
        [Required(ErrorMessage = MessagesConstant.MSG_PROJECT_WITHOU_TITLE)]
        [StringLength(80, ErrorMessage = MessagesConstant.MSG_TITLE_GREATER_80)]
        public string Title { get; set; } = null!;
        
        [Column("description")]
        [MaxLength(500)]
        public string? Description { get; set; }
        
        [Column("type")]
        public TypeProject Type { get; set; }  
        
        [Column("state")]
        public StateProject State { get; set; }
        
        [Column("start")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = MessagesConstant.MSG_STAR_IS_NULL)]
        public DateTime? Start { get; set; }
        
        [Column("end")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage =MessagesConstant.MSG_END_IS_NULL)]
        public DateTime? End { get; set; }
        
        [Column("detail")]
        [StringLength(500, ErrorMessage = MessagesConstant.MSG_DESCRIPTION_GREATER_500)]
        public string? Detail { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ( Start >= End )
            {
                yield return new ValidationResult(MessagesConstant.MSG_START_GREATER_EQUEL_THAN_FINISH,
                    new[] { nameof(Start), nameof(End) });
            }
        }
    }
}
