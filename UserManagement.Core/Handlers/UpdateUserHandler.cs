using MediatR;
using UserManagement.Domain.Commands;

namespace UserManagement.Core.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
