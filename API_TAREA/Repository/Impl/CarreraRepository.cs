
using API_TAREA.Data;
using Microsoft.EntityFrameworkCore;

namespace API_TAREA.Repository.Impl
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly ContextDB _contextDB;
        public CarreraRepository(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }
        public async Task<string> BuscarNombre(Guid idCarrera)
        {
            var carrera = await _contextDB.Carreras.FirstOrDefaultAsync(carrera => carrera.Id.Equals(idCarrera));
            return carrera.Nombre;
        }
    }
}
