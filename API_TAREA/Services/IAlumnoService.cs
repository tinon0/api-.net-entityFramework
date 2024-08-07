using API_TAREA.DTO;

namespace API_TAREA.Services
{
    public interface IAlumnoService
    {
        Task<AlumnosDto> CrearAlumno(string nombre, string apellido, string legajo, Guid idRol);
        Task<bool> EliminarAlumno(string nombre);
        Task<AlumnosDto> EditarAlumno(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol);
    }
}
