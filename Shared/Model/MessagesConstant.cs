namespace Gisfpp_projects.Shared.Model
{
    public static class MessagesConstant
    {
        // MESSAGES PROJECT
        public const string MSG_PROJECT_WITHOU_TITLE = "Debe especificarle un \"Título\" al Proyecto.";
        public const string MSG_TITLE_GREATER_80 = "El \"Título\" del Proyecto no debe superar los 80 caractéres.";
        public const string MSG_STATE_DISTINCT_GENERATED = "El estado del proyecto debe ser GENERATED.";
        public const string MSG_START_GREATER_EQUEL_THAN_FINISH = "La Fecha de finalizacion del proyecto debe ser posterior a la fecha de inicio.";
        public const string MSG_STAR_IS_NULL = "Debe especificarle una \"fecha de inicio\" al Proyecto.";
        public const string MSG_END_IS_NULL = "Debe especificarle una \"fecha de finalización\" al Proyecto.";
        public const string MSG_DESCRIPTION_GREATER_500 = "\"La Descripcion\" del Proyecto no debe ser mayor a 500 caracteres.";
        public const string MSG_UNEXPECTED_ERROR = "Error inesperado";
    }
}