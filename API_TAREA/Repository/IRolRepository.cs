namespace API_TAREA.Repository
{
    public interface IRolRepository
    {
        Task<string> BuscarNombre(Guid id);
    }
}
