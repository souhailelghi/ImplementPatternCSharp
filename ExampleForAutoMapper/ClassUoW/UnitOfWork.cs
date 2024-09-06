using ExampleForAutoMapper.Data;
using ExampleForAutoMapper.InterfaceUow;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using ExampleForAutoMapper.Repositorys;

namespace ExampleForAutoMapper.ClassUoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
       
        
        public IBaseRepository<Customer> Customers { get; private set; }

        public IBaseRepository<Employee> Employees { get; private set; }

        public IBaseRepository<Product> Products { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new BaseRepository<Customer>(_context);
            Employees = new BaseRepository<Employee>(_context);
            Products = new BaseRepository<Product>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
