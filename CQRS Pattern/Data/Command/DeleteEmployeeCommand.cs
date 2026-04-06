using MediatR;

namespace CQRS_Pattern.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

}
