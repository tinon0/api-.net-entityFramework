using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("cursos")]
    public class Cursos
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Horarios { get; set; }
        public Guid IdCarrera { get; set; }
        [ForeignKey("IdCarrera")] public Carreras Carrera { get; set; }
    }
}
