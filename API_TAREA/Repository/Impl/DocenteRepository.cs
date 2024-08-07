using API_TAREA.Data;
using API_TAREA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TAREA.Repository.Impl
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly ContextDB _contextDB;
        public DocenteRepository(ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }
        public async Task<Docentes> CrearDocente(string nombre, string apellido, string legajo, Guid idRol)
        {
            var docente = new Docentes();
            docente.Nombre = nombre;
            docente.Apellido = apellido;
            docente.Legajo = legajo;
            docente.IdRol = idRol;

            _contextDB.Docentes.Add(docente);
            await _contextDB.SaveChangesAsync();

            return docente;
        }

        public async Task<Docentes> EditarDocente(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol)
        {
            var docenteToEdit = await _contextDB.Docentes.FirstOrDefaultAsync(docente => docente.Legajo.Equals(legajo));
            if(docenteToEdit != null)
            {
                docenteToEdit.Nombre = nuevoNombre;
                docenteToEdit.Apellido = nuevoApellido;
                docenteToEdit.Legajo = nuevoLegajo;
                docenteToEdit.IdRol = idRol;

                _contextDB.Docentes.Update(docenteToEdit);
                await _contextDB.SaveChangesAsync();

                return docenteToEdit;
            }
            else
            {
                throw new Exception("Docente no existe");
            }
        }

        public async Task<bool> EliminarDocente(string nombre)
        {
            var docenteToDelete = await _contextDB.Docentes.FirstOrDefaultAsync(docente => docente.Nombre.Equals(nombre));
            if (docenteToDelete != null)
            {
                _contextDB.Docentes.Remove(docenteToDelete);
                await _contextDB.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
