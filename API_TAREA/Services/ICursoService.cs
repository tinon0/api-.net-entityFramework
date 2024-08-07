using API_TAREA.DTO;

namespace API_TAREA.Services
{
    public interface ICursoService
    {
        Task<CursosDto> crearCurso(string nombre, string horarios, Guid idCarrera);
        Task<bool> eliminarCurso(string nombre);
        Task<CursosDto> modificarCurso(string nombre, string nuevoNombre, string horarios, Guid idCarrera);
    }
}
