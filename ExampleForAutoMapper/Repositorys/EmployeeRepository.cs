using ExampleForAutoMapper.Data;
using ExampleForAutoMapper.Dto;
using ExampleForAutoMapper.IRepositorys;
using ExampleForAutoMapper.Model;
using Microsoft.EntityFrameworkCore;

namespace ExampleForAutoMapper.Repositorys
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Employee> AddAsync(Employee entity)
        {
          await _db.Employees.AddAsync(entity);
          await _db.SaveChangesAsync();
           return entity;
        }

        public async Task<Employee> DeleteAsync(int id)
        {
           var idEp = await _db.Employees.FindAsync(id);
             _db.Employees.Remove(idEp);
           await _db.SaveChangesAsync();
            return idEp;
        }

        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _db.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _db.Employees.FindAsync(id);
        }

        public async Task<Employee> UpdateAsync(int id, Employee employeeDto)
        {
            var employee = await _db.Employees.FindAsync(id);
            employee.Name = employeeDto.Name;
            employee.Age = employeeDto.Age;
            employee.Amount = employeeDto.Amount;
            employee.TypeEmployee = employeeDto.TypeEmployee;
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
            return employee;


        }
    }
}
