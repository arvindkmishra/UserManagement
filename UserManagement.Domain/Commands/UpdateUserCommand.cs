using MediatR;

namespace UserManagement.Domain.Commands
{
    public class UpdateUserCommand :IRequest
    {
        public required string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
