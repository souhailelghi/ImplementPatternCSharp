using ExampleForAutoMapper.Model;

namespace ExampleForAutoMapper.Servecies.Abstracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);


        Customer Add (Customer entity);


        Customer Update(int id, Customer entity);
        void Delete(int id);
    }
}
