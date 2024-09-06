using AutoMapper;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleForAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(IBaseRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Add(customer);
            return Ok(customerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _customerRepository.Update(id, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
            return NoContent();
        }
    }
}
