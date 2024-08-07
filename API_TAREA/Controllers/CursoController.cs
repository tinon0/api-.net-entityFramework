using API_TAREA.Comandos;
using API_TAREA.Resultados;
using API_TAREA.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_TAREA.Controllers
{
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;
        public CursoController(ICursoService _cursoService)
        {
            this._cursoService = _cursoService;
        }

        [HttpPost]
        [Route("/crearCurso")] //PONER EL ROL DE ADMIN
        public async Task<ResultadoBase> CrearCurso(NuevoCurso nuevoCurso)
        {
            var resultado = new ResultadoBase();
            var cursoNuevo = await _cursoService.crearCurso(nuevoCurso.Nombre, nuevoCurso.Horarios, nuevoCurso.IdCarrera);
            if(cursoNuevo != null)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se creo un Curso correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = cursoNuevo;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo crear un Curso";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                return resultado;
            }
        }
        [HttpDelete]
        [Route("/eliminarCurso/{nombre}")] //PONER EL ROL DE ADMIN
        public async Task<ResultadoBase> EliminarCurso(string nombre)
        {
            var resultado = new ResultadoBase();
            var eliminarCurso = await _cursoService.eliminarCurso(nombre);
            if (eliminarCurso)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se elimino el Curso '"+ nombre + "' correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = eliminarCurso;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo eliminar el Curso '" + nombre + "'";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = eliminarCurso;
                return resultado;
            }
        }
        [HttpPut]
        [Route("/editarCurso")] //PONER EL ROL DE ADMIN
        public async Task<ResultadoBase> EditarCurso(BuscarCurso curso)
        {
            var resultado = new ResultadoBase();
            var cursoEditado = await _cursoService.modificarCurso(curso.Nombre, curso.NuevoNombre, curso.Horario, curso.IdCarrera);
            if(cursoEditado != null)
            {
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se modifico el Curso '" + curso.Nombre + "' correctamente";
                resultado.Ok = true;
                resultado.StatusCode = 200;
                resultado.Resultado = cursoEditado;
                return resultado;
            }
            else
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "No se pudo modificar el Curso '" + curso.Nombre + "'";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                return resultado;
            }
        }
    }
}
