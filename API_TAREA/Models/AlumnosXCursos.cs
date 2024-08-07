using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.Models
{
    [Table("alumnosXcursos")]
    public class AlumnosXCursos
    {
        public Guid Id { get; set; }
        public Guid IdCurso { get; set; }
        public Guid IdAlumno { get; set; }
        public DateTime FechaAlta { get; set; }
        [ForeignKey("IdCurso")] public Cursos Curso { get; set; }
        [ForeignKey("IdAlumno")] public Alumnos Alumno { get; set; }
    }
}
