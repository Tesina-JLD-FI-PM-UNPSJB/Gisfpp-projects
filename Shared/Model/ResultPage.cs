namespace Gisfpp_projects.Shared.Model
{
    public class ResultPage<T>
    {
        public IEnumerable<T>? result { get; set; }

        public bool hasMoreElements { get; set; }

        public int numberPage { get; set; }

        public int sizePage { get; set; }

        public long totalElements { get; set; }
    }
}
