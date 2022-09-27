using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Infrastructure.Persistence;

namespace UniversityApp.Infrastructure.Services
{
    public class BaseCRUDRepository<Tkey, Tmodel, Tdb> : IBaseCRUDRepository<Tkey, Tmodel, Tdb> where Tmodel : class where Tdb : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BaseCRUDRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        ///*CREATE*/
        public virtual async Task<Tmodel> Create(Tmodel model)
        {
            Tdb entity = _mapper.Map<Tdb>(model);
            await _context.Set<Tdb>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Tmodel>(entity);
        }

        ///*READ*/
        public virtual async Task<List<Tmodel>> GetAll()
        {
            return _mapper.Map<List<Tmodel>>(await _context.Set<Tdb>().ToListAsync());
        }

        public virtual async Task<Tmodel?> GetById(Tkey id)
        {
            Tdb entity = await _context.Set<Tdb>().FindAsync(id);

            if (entity is not null)
                return _mapper.Map<Tmodel>(entity);
            return null;
        }

        ///*UPDATE*/
        public virtual async Task<Tmodel> Update(Tkey id, Tmodel model)
        {
            Tdb entity = _context.Set<Tdb>().Find(id);

            _mapper.Map(model, entity);
            _context.Set<Tdb>().Attach(entity);
            _context.Set<Tdb>().Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Tmodel>(entity);
        }

        ///*DELETE*/
        public virtual async Task<Tmodel?> Delete(Tkey id)
        {
            Tdb entity = _context.Set<Tdb>().Find(id);
            if (entity is not null)
            {
                _context.Set<Tdb>().Remove(entity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Tmodel>(entity);
            }
            return null;
        }
    }
}
