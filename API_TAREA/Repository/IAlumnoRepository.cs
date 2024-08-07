using API_TAREA.Models;

namespace API_TAREA.Repository
{
    public interface IAlumnoRepository
    {
        Task<Alumnos> CrearAlumno(string nombre, string apellido, string legajo, Guid idRol);
        Task<bool> EliminarAlumno(string nombre);
        Task<Alumnos> EditarAlumno(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol);
    }
}
