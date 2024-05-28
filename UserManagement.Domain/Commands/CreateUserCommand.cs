using MediatR;

namespace UserManagement.Domain.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
