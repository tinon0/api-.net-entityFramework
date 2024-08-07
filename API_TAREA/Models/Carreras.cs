using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("carreras")]
    public class Carreras
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
