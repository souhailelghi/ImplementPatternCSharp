using AutoMapper;
using ExampleForAutoMapper.Data;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.Enums;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleForAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeesController(IMapper mapper  , IRepository<Employee> employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

       
        

        [HttpGet]
     
        public async Task<IActionResult> GetAllEmployees()
         {
            // var emp = employees.Select(x => new { x.Id, x.Name , x.Age ,x.Amount, x.TypeEmployee }).ToList();
            // 2 : return Ok(_mapper.Map<List<EmployeeDto>>(_context.Employees.ToList()));
            var allEmp = await _employeeRepository.GetAllAsync();
               return Ok(_mapper.Map<List<EmployeeDto>>(allEmp));
         }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            // var p = await _context.Employees.Find(id);
            var employee = await _employeeRepository.GetByIdAsync(id);
            var perDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(perDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.AddAsync(employee);
            return Ok("added success !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            
            await _employeeRepository.DeleteAsync(id);
            return Ok("remove Employee success !");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
             await _employeeRepository.UpdateAsync(id, employee);
            return Ok("updated Employee success !");
        }



    }
}
