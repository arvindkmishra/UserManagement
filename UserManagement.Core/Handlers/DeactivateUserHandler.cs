using MediatR;
using UserManagement.Domain.Commands;
using UserManagement.Domain.Repositories;

namespace UserManagement.Core.Handlers
{
    public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeactivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            user.Deactivate();
            await _userRepository.UpdateAsync(user);
        }
    }
}
