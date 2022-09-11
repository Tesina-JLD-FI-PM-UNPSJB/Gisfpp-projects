namespace Gisfpp_projects.Project.Model.Dto
{

    public record ProjectDTO
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
        public string? ResolutionNumber { get; set; }
        public string Title { get; }
        public string? Description { get; set; }
        public TypeProject Type { get; }
        public StateProject State { get; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Detail { get; set; }

        public ProjectDTO(string title,
                          TypeProject type,
                          StateProject state,
                          DateTime? start,
                          DateTime? end)
        {
            Title = title;
            Type = type;
            State = state;
            Start = start;
            End = end;
        }
    }
}
