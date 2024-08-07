using API_TAREA.DTO;
using API_TAREA.Repository;
using API_TAREA.Repository.Impl;
using AutoMapper;

namespace API_TAREA.Services.Impl
{
    public class DocentesServiceImpl : IDocenteService
    {
        private readonly IDocenteRepository _docenteRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;
        public async Task<DocentesDto> CrearDocente(string nombre, string apellido, string legajo, Guid idRol)
        {
            var docenteNuevo = await _docenteRepository.CrearDocente(nombre, apellido, legajo, idRol);
            var docenteDto = _mapper.Map<DocentesDto>(docenteNuevo);
            docenteDto.Rol = await _rolRepository.BuscarNombre(idRol);
            return docenteDto;
        }

        public async Task<DocentesDto> EditarDocente(string legajo, string nuevoNombre, string nuevoApellido, string nuevoLegajo, Guid idRol)
        {
            var docenteEditado = await _docenteRepository.EditarDocente(legajo, nuevoNombre, nuevoApellido, nuevoLegajo, idRol);
            var docenteDto = _mapper.Map<DocentesDto>(docenteEditado);
            docenteDto.Rol = await _rolRepository.BuscarNombre(idRol);
            return docenteDto;
        }

        public async Task<bool> EliminarDocente(string nombre)
        {
            return await _docenteRepository.EliminarDocente(nombre);
        }
    }
}
