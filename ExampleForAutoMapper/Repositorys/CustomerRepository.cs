using ExampleForAutoMapper.Data;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;

namespace ExampleForAutoMapper.Repositorys
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context) : base(context)
        {
            
        }


    }
}
