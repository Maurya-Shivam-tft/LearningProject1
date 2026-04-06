using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Handler.CommandHandler
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.Id);

            if(employee == null)
            {
                return 0;
            }

            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Address = request.Address;
            employee.Phone = request.Phone;
            
            
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
