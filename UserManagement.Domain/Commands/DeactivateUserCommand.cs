using MediatR;

namespace UserManagement.Domain.Commands
{
    public class DeactivateUserCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
