using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("roles")]
    public class Roles
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
