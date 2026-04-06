using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Query
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
