using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using CQRS_Pattern.Services;
using MediatR;

namespace CQRS_Pattern.Data.Handler.QueryHandler
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.Id);
        }
    }

    //public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    //{
    //    private readonly IEmployeeRepository _employeeRepository;

    //    public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
    //    {
    //        _employeeRepository = employeeRepository;
    //    }

    //    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    //    {
    //        return await _employeeRepository.GetEmployeeByIdAsync(request.Id);

    //    }
    //}
}
