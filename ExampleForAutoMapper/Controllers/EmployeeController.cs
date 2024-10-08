﻿using AutoMapper;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            var employees = _unitOfWork.Employees.GetAll();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = _unitOfWork.Employees.GetById(id);
            if (employee == null) return NotFound();
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.Complete();
            return Ok(employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.Employees.Update(id, employee);
            _unitOfWork.Complete();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            _unitOfWork.Employees.Delete(id);
            _unitOfWork.Complete();
            return NoContent();
        }
        //private readonly IBaseRepository<Employee> _employeeRepository;
        //private readonly IMapper _mapper;

        //public EmployeeController(IBaseRepository<Employee> employeeRepository, IMapper mapper)
        //{
        //    _employeeRepository = employeeRepository;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        //{
        //    var employees = _employeeRepository.GetAll();
        //    var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        //    return Ok(employeeDtos);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        //{
        //    var employee = _employeeRepository.GetById(id);
        //    if (employee == null) return NotFound();
        //    var employeeDto = _mapper.Map<EmployeeDto>(employee);
        //    return Ok(employeeDto);
        //}

        //[HttpPost]
        //public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] EmployeeDto employeeDto)
        //{
        //    var employee = _mapper.Map<Employee>(employeeDto);
        //    _employeeRepository.Add(employee);
        //    return Ok(employeeDto);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        //{
        //    var employee = _mapper.Map<Employee>(employeeDto);
        //    _employeeRepository.Update(id, employee);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteEmployee(int id)
        //{
        //    _employeeRepository.Delete(id);
        //    return NoContent();
        //}
    }
}
