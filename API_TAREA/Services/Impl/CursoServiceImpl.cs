using API_TAREA.DTO;
using API_TAREA.Repository;
using AutoMapper;

namespace API_TAREA.Services.Impl
{
    public class CursoServiceImpl : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly ICarreraRepository _carreraRepository;
        private readonly IMapper _mapper;
        public CursoServiceImpl(ICursoRepository _cursoRepository, IMapper _mapper, ICarreraRepository _carreraRepository)
        {
            this._cursoRepository = _cursoRepository;
            this._mapper = _mapper;
            this._carreraRepository = _carreraRepository;
        }
        public async Task<CursosDto> crearCurso(string nombre, string horarios, Guid idCarrera)
        {
            var curso = await _cursoRepository.crearCurso(nombre, horarios, idCarrera);
            var cursoDto = _mapper.Map<CursosDto>(curso);
            cursoDto.Carrera = await _carreraRepository.BuscarNombre(idCarrera);
            return cursoDto;
        }

        public async Task<bool> eliminarCurso(string nombre)
        {
            bool resultado = await _cursoRepository.eliminarCurso(nombre);
            return resultado;
        }

        public async Task<CursosDto> modificarCurso(string nombre, string nuevoNombre, string horarios, Guid idCarrera)
        {
            var cursoUpdated = await _cursoRepository.modificarCurso(nombre, nuevoNombre, horarios, idCarrera);
            var cursoDto = _mapper.Map<CursosDto>(cursoUpdated);
            cursoDto.Carrera = await _carreraRepository.BuscarNombre(idCarrera);
            return cursoDto;
        }
    }
}
