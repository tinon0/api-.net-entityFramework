using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("docentesXcursos")]
    public class DocentesXCursos
    {
        public Guid Id { get; set; }
        public Guid IdCurso { get; set; }
        public Guid IdDocente { get; set; }
        public DateTime FechaAlta { get; set; }
        [ForeignKey("IdCurso")] public Cursos Curso { get; set; }
        [ForeignKey("IdDocente")] public Docentes Docente { get; set; }
    }
}
