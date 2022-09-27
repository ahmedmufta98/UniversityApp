namespace UniversityApp.Domain.Interfaces
{
    public interface IBaseGetRepository<Tkey, Tmodel> where Tmodel : class
    {
        Task<List<Tmodel>> GetAll();
        Task<Tmodel?> GetById(Tkey id);
    }
}
