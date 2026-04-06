using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        //Get: api/<EmployeeController>

        [HttpGet]
        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            return employeeList;
        }

        [HttpGet("{id}")]

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery() { Id = id});
        }

        [HttpPost]

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var emp = await _mediator.Send(new CreateEmployeeCommand(employee.Name, employee.Address, employee.Phone, employee.Email));

            return emp;
        }

        [HttpPut]

        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(id:employee.Id, name: employee.Name, address: employee.Address, email: employee.Email, phone:employee.Phone));
            if(result == 0)
            {
                return NotFound("Employee Not Found");
            }

            return Ok("Employee updated successfuly");
        }

        [HttpDelete("{id}")]

        public async Task<int> DeleteEmployee(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { Id = id});
        }


    }
    
}
