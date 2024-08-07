namespace API_TAREA.Repository
{
    public interface ICarreraRepository
    {
        Task<string> BuscarNombre(Guid idCarrera);
    }
}
