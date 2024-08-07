using API_TAREA.DTO;
using API_TAREA.Models;
using AutoMapper;

namespace API_TAREA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cursos, CursosDto>();
            CreateMap<Alumnos, AlumnosDto>();
        }
    }
}
