using CQRS_Pattern.Data.Query;
using CQRS_Pattern.Model;
using CQRS_Pattern.Services;
using MediatR;
using System.Security.AccessControl;

namespace CQRS_Pattern.Data.Handler.QueryHandler
{
    public class GetEmployeeListHandler : IRequestHandler<GetEmployeeListQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeListAsync();
        }
    }
}
