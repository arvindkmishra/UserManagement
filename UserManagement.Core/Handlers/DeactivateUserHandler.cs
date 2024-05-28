using MediatR;
using UserManagement.Domain.Commands;

namespace UserManagement.Core.Handlers
{
    public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand>
    {
        public Task Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
