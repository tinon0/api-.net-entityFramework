
using API_TAREA.Data;
using Microsoft.EntityFrameworkCore;

namespace API_TAREA.Repository.Impl
{
    public class RolRepository : IRolRepository
    {
        private readonly ContextDB _contextDB;
        public RolRepository(ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }
        public async Task<string> BuscarNombre(Guid id)
        {
            var nombre = await _contextDB.Roles.FirstOrDefaultAsync(rol => rol.Id.Equals(id));
            return nombre.Nombre;
        }
    }
}
