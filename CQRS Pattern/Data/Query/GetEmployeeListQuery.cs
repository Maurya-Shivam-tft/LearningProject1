using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Query
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    { 

    }
}
