using API_TAREA.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TAREA.DTO
{
    public class CursosDto
    {
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Horarios { get; set; }
        public string Carrera { get; set; }
    }
}
