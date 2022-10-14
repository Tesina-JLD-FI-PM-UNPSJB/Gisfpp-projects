using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace Gisfpp_projects.Project.Model.Dto
{

    public record ProjectDTO
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public string? ResolutionNumber { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public TypeProject? Type { get; set; }
        
        public StateProject? State { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Detail { get; set; }

        public ProjectDTO()
        {
        }

        public ProjectDTO(int? id, string? code, string? resolutionNumber, string? title, 
            string? description, TypeProject? type, StateProject? state, 
            DateTime? start, DateTime? end, string? detail)
        {
            Id = id;
            Code = code;
            ResolutionNumber = resolutionNumber;
            Title = title;
            Description = description;
            Type = type;
            State = state;
            Start = start;
            End = end;
            Detail = detail;
        }
    }
}
