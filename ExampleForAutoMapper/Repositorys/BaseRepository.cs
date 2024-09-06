using ExampleForAutoMapper.Data;
using ExampleForAutoMapper.IRepositorys;

namespace ExampleForAutoMapper.Repositorys
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(int id, T entity)
        {
            var existingEntity = _context.Set<T>().Find(id);
            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity), "Entity not found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return existingEntity;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity not found.");
            }

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
