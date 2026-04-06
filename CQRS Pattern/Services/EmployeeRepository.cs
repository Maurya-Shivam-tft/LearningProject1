using CQRS_Pattern.Data;
using CQRS_Pattern.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CQRS_Pattern.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dbContext;

        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var foundEmp = _dbContext.Employees.Where(x  => x.Id == id).FirstOrDefault();

            if(foundEmp != null)
            {
                _dbContext.Employees.Remove(foundEmp);
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
            
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            var searchedEmp = await _dbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();

            return searchedEmp;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            var empList  = await _dbContext.Employees.ToListAsync();
            return empList;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {           
            var existingEmp = await _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
            if (existingEmp == null)
            {
                return 0;
            }

            existingEmp.Name = employee.Name;
            existingEmp.Email = employee.Email;
            existingEmp.Phone = employee.Phone;
            existingEmp.Address = employee.Address;
                      
            _dbContext.Employees.Update(existingEmp);
            return await _dbContext.SaveChangesAsync();
                       
        }
    }
}
