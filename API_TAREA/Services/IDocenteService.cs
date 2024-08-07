using API_TAREA.DTO;

namespace API_TAREA.Services
{
    public interface IDocenteService
    {
        Task<DocentesDto> CrearDocente(string nombre, string apellido, string legajo, Guid idRol);
        Task<bool> EliminarDocente(string nombre);
        Task<DocentesDto> EditarDocente(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol);
    }
}
