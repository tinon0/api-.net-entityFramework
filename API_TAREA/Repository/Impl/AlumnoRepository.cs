using API_TAREA.Data;
using API_TAREA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace API_TAREA.Repository.Impl
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ContextDB _contextDB;
        public AlumnoRepository(ContextDB _contextDB)
        {
            this._contextDB = _contextDB;
        }

        public async Task<Alumnos> CrearAlumno(string nombre, string apellido, string legajo, Guid idRol)
        {
            var alumno = new Alumnos();
            alumno.Nombre = nombre;
            alumno.Apellido = apellido;
            alumno.Legajo = legajo;
            alumno.IdRol = idRol;

            _contextDB.Alumnos.Add(alumno);
            await _contextDB.SaveChangesAsync();

            return alumno;
        }

        public async Task<Alumnos> EditarAlumno(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol)
        {
            var alumnoToEdit = await _contextDB.Alumnos.FirstOrDefaultAsync(alumno => alumno.Legajo.Equals(legajo));
            if(alumnoToEdit != null)
            {
                alumnoToEdit.Nombre = nuevoNombre;
                alumnoToEdit.Apellido = nuevoApellido;
                alumnoToEdit.Legajo = nuevoLegajo;
                alumnoToEdit.IdRol = idRol;

                _contextDB.Alumnos.Update(alumnoToEdit);
                await _contextDB.SaveChangesAsync();

                return alumnoToEdit;
            }
            else
            {
                throw new Exception("Alumno no existe");
            }
        }

        public async Task<bool> EliminarAlumno(string nombre)
        {
            var alumnoToDelete = await _contextDB.Alumnos.FirstOrDefaultAsync(alumno => alumno.Nombre.Equals(nombre));
            if(alumnoToDelete != null)
            {
                _contextDB.Alumnos.Remove(alumnoToDelete);
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
