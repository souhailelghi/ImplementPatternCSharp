using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using ExampleForAutoMapper.Servecies.Abstracts;

namespace ExampleForAutoMapper.Servecies.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        
        }


        public Customer Add(Customer entity)
        {
            _customerRepository.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
