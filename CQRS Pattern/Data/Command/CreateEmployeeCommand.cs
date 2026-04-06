using CQRS_Pattern.Model;
using MediatR;

namespace CQRS_Pattern.Data.Command
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public CreateEmployeeCommand(string name, string add, string email, string phone)
        {
             Name = name;
             Address = add;
             Email = email;
             Phone = phone;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }
}
