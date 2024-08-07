using API_TAREA.Comandos;
using API_TAREA.Models;
using API_TAREA.Resultados;
using API_TAREA.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREA.Controllers
{
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnoController(IAlumnoService _alumnoService)
        {
            this._alumnoService = _alumnoService;
        }
        [HttpPost]
        [Route("/crearAlumno")] //ROL ADMIN
        public async Task<ResultadoBase> CrearAlumno(NuevoAlumno nuevoAlumno)
        {
            var resultado = new ResultadoBase();
            var alumnoNuevo = await _alumnoService.CrearAlumno(nuevoAlumno.Nombre, nuevoAlumno.Apellido, nuevoAlumno.Legajo, nuevoAlumno.IdRol);
            if (alumnoNuevo != null)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se creo un Alumno correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = alumnoNuevo;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo crear un Alumno";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                return resultado;
            }
        }
        [HttpDelete]
        [Route("/eliminarAlumno/{nombre}")] //ROL ADMIN
        public async Task<ResultadoBase> EliminarAlumno(string nombre)
        {
            var resultado = new ResultadoBase();
            var eliminarAlumno = await _alumnoService.EliminarAlumno(nombre);
            if (eliminarAlumno)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se elimino el Alumno '" + nombre +"' correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = eliminarAlumno;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo eliminar el Alumno '" + nombre + "'";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = eliminarAlumno;
                return resultado;
            }
        }
        [HttpPut]
        [Route("/editarAlumno")] //ROL ALUMNO
        public async Task<ResultadoBase> EditarAlumno(BuscarAlumno alumno)
        {
            var resultado = new ResultadoBase();
            var alumnoEditado = await _alumnoService.EditarAlumno(alumno.Legajo, alumno.NuevoNombre, alumno.NuevoApellido, alumno.NuevoLegajo, alumno.IdRol);
            if (alumnoEditado != null)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se modifico el Alumno '" + alumnoEditado.Nombre + "' correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = alumnoEditado;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo modificar el Alumno '" + alumnoEditado.Nombre + "'";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                return resultado;
            }
        }
    }
}
