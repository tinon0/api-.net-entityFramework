using API_TAREA.Data;
using API_TAREA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TAREA.Repository.Impl
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ContextDB _contextDB;
        public CursoRepository(ContextDB contextDB)
        {
            this._contextDB = contextDB;
        }

        public async Task<Cursos> crearCurso(string nombre, string horarios, Guid idCarrera)
        {
            var curso = new Cursos();
            curso.Id = Guid.NewGuid();
            curso.Nombre = nombre;
            curso.FechaCreacion = DateTime.Now;
            curso.Horarios = horarios;
            curso.IdCarrera = idCarrera;

            _contextDB.Add(curso);
            await _contextDB.SaveChangesAsync();

            return curso;
        }

        public async Task<bool> eliminarCurso(string nombre)
        {
            var cursoToDelete = await _contextDB.Cursos.FirstOrDefaultAsync(curso => curso.Nombre.Equals(nombre));
            if(cursoToDelete != null)
            {
                _contextDB.Remove(cursoToDelete);
                await _contextDB.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Cursos> modificarCurso(string nombre, string nuevoNombre, string horarios, Guid idCarrera)
        {
            var cursoToUpdate = await _contextDB.Cursos.FirstOrDefaultAsync(curso => curso.Nombre.Equals(nombre));
            if(cursoToUpdate != null)
            {
                cursoToUpdate.Nombre = nuevoNombre;
                cursoToUpdate.Horarios = horarios;
                cursoToUpdate.IdCarrera = idCarrera;

                _contextDB.Update(cursoToUpdate);
                await _contextDB.SaveChangesAsync();

                return cursoToUpdate;
            }
            else
            {
                throw new Exception("No se encontro");
            }
        }
    }
}
