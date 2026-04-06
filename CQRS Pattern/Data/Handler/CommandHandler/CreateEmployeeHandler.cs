using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Model;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Handler.CommandHandler
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee emp = new Employee
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,

            };

            return await _employeeRepository.AddEmployeeAsync(emp);
        }

    }


    //public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee> 
    //{ 
    //    private readonly IEmployeeRepository _employeeRepository;

    //    public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
    //    {
    //        _employeeRepository = employeeRepository;
    //    }

    //    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    //    {
    //        var emp = new Employee
    //        {
    //            Name = request.Name,
    //            Address = request.Address,
    //            Email = request.Email,
    //            Phone = request.Phone,
    //        };

    //        return await _employeeRepository.AddEmployeeAsync(emp);
    //    }
    //}

}
