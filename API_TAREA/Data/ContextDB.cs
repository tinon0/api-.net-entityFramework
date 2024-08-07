using API_TAREA.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TAREA.Data
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }
        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<AlumnosXCursos> AlumnosXCursos { get; set; }
        public DbSet<Carreras> Carreras { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Docentes> Docentes { get; set; }
        public DbSet<DocentesXCursos> DocentesXCursos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
