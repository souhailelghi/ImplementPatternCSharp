using AutoMapper;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.InterfaceUow;
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
        //private readonly IBaseRepository<Customer> _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // 1
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        //{
        //    var customers = _customerRepository.GetAll();
        //    var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
        //    return Ok(customerDtos);
        //}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll();
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        // 2
        //[HttpGet("{id}")]
        //public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        //{
        //    var customer = _customerRepository.GetById(id);
        //    if (customer == null) return NotFound();
        //    var customerDto = _mapper.Map<CustomerDto>(customer);
        //    return Ok(customerDto);
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            if (customer == null) return NotFound();
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }
        //3
        //[HttpPost]
        //public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CustomerDto customerDto)
        //{
        //    var customer = _mapper.Map<Customer>(customerDto);
        //    _customerRepository.Add(customer);
        //    return Ok(customerDto);
        //}
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
            return Ok(customerDto);
        }


        //4
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        //{
        //    var customer = _mapper.Map<Customer>(customerDto);
        //    _customerRepository.Update(id, customer);
        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _unitOfWork.Customers.Update(id, customer);
            _unitOfWork.Complete();
            return NoContent();
        }
        //5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteCustomer(int id)
        //{
        //    _customerRepository.Delete(id);
        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            _unitOfWork.Customers.Delete(id);
            _unitOfWork.Complete();
            return NoContent();
        }

    }
}
