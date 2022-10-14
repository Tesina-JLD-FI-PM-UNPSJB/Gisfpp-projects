using System.ComponentModel.DataAnnotations;
namespace Gisfpp_projects.Shared
{
    public class ModelInvalidException : Exception
    {
        public ICollection<ValidationResult>? ValidationResults { get; }

        public ModelInvalidException(ICollection<ValidationResult> results)
        {
            this.ValidationResults = results;
        }

        public ModelInvalidException(string? message) : base(message)
        {
        }

        public ModelInvalidException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public string GetMessageValidations()
        {
            var result = "";
            const string separator = " - ";

            foreach (var item in ValidationResults!)
            {
                result = string.Concat(result, item.ErrorMessage, separator);
            }
            result = removeLastSeparator(result, separator);

            return result;
        }

        private static string removeLastSeparator(string result, string separator)
        {
            var indexOfLastSeparator = result.LastIndexOf(separator);
            result = indexOfLastSeparator != -1
                        ? result.Substring(0, indexOfLastSeparator)
                        : result;
            return result;
        }
    }
}
