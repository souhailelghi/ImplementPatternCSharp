using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;

namespace ExampleForAutoMapper.InterfaceUow
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Customer> Customers { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Product> Products { get; }

        int Complete();
    }
}
