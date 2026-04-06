using CQRS_Pattern.Data.Command;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Handler.CommandHandler
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
            if (emp == null)
            {
                return 0;
            }
            return await _employeeRepository.DeleteEmployeeAsync(request.Id);
        }
    }

    //public class DeleteEmployeeByIdHandler : IRequestHandler<DeleteEmployeeCommand, int>
    //{
    //    private readonly IEmployeeRepository _employeeRepository;
    //    public DeleteEmployeeByIdHandler(IEmployeeRepository employeeRepository)
    //    {
    //        _employeeRepository = employeeRepository;
    //    }

    //    public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    //    {
    //        var emp = await _employeeRepository.GetEmployeeByIdAsync(request.Id);
    //        if(emp == null)
    //        {
    //            return 0;
    //        }

    //        return await _employeeRepository.DeleteEmployeeAsync(request.Id);
    //    }
    //}
}
