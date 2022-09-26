namespace Gisfpp_projects.Project.Exceptions
{
    public class ProjectRepositoryException : Exception
    {
        public ProjectRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
