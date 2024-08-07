using API_TAREA.Models;

namespace API_TAREA.Repository
{
    public interface IDocenteRepository
    {
        Task<Docentes> CrearDocente(string nombre, string apellido, string legajo, Guid idRol);
        Task<bool> EliminarDocente(string nombre);
        Task<Docentes> EditarDocente(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol);
    }
}
