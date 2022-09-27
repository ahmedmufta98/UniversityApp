namespace UniversityApp.Domain.Interfaces
{
    public interface IBaseCRUDRepository<Tkey, Tmodel, Tdb> : IBaseGetRepository<Tkey, Tmodel> where Tmodel : class where Tdb : class
    {
        Task<Tmodel> Create(Tmodel model);
        Task<Tmodel> Update(Tkey id, Tmodel model);
        Task<Tmodel?> Delete(Tkey id);
    }
}
