using API_TAREA.Models;

namespace API_TAREA.Repository
{
    public interface ICursoRepository
    {
        Task<Cursos> crearCurso(string nombre, string horarios, Guid idCarrera);
        Task<bool> eliminarCurso(string nombre);
        Task<Cursos> modificarCurso(string nombre, string nuevoNombre, string horarios, Guid idCarrera);
    }
}
