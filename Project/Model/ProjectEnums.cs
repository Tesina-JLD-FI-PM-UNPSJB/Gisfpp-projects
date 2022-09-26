using System.Runtime.Serialization;

namespace Gisfpp_projects.Project.Model
{
    public enum TypeProject
    {
        [EnumMember(Value = "Interno")] INTERN,
        [EnumMember(Value = "Empresa")] COMPANY,
        [EnumMember(Value = "Invesigación")] RESEARCH,
        [EnumMember(Value = "Extensión")] EXTENSION
    }

    public enum StateProject
    {
        [EnumMember(Value ="Generado")] GENERATED,
        [EnumMember(Value = "Activo")] ACTIVE,
        [EnumMember(Value = "Suspendido")] SUSPENDED,
        [EnumMember(Value = "Cancelado")] CANCELLED
    }

}
