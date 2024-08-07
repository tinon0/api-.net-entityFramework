using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("docentes")]
    public class Docentes
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Legajo { get; set; }
        public Guid IdRol { get; set; }
        [ForeignKey("IdRol")] public Roles Rol { get; set; }
    }
}
