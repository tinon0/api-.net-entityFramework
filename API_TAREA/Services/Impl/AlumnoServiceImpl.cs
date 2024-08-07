using API_TAREA.DTO;
using API_TAREA.Repository;
using AutoMapper;

namespace API_TAREA.Services.Impl
{
    public class AlumnoServiceImpl : IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;

        public AlumnoServiceImpl(IAlumnoRepository _alumnoRepository, IMapper _mapper, IRolRepository _rolRepository)
        {
            this._alumnoRepository = _alumnoRepository;
            this._mapper = _mapper;
            this._rolRepository = _rolRepository;
        }
        public async Task<AlumnosDto> CrearAlumno(string nombre, string apellido, string legajo, Guid idRol)
        {
            var alumnoNuevo = await _alumnoRepository.CrearAlumno(nombre, apellido, legajo, idRol);
            var alumnoDto = _mapper.Map<AlumnosDto>(alumnoNuevo);
            alumnoDto.Rol = await _rolRepository.BuscarNombre(idRol);
            return alumnoDto;
        }

        public async Task<AlumnosDto> EditarAlumno(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol)
        {
            var alumnoEditado = await _alumnoRepository.EditarAlumno(legajo, nuevoNombre, nuevoApellido, nuevoLegajo, idRol);
            var alumnoDto = _mapper.Map<AlumnosDto>(alumnoEditado);
            alumnoDto.Rol = await _rolRepository.BuscarNombre(idRol);
            return alumnoDto;
        }

        public async Task<bool> EliminarAlumno(string nombre)
        {
            return await _alumnoRepository.EliminarAlumno(nombre);
        }
    }
}
