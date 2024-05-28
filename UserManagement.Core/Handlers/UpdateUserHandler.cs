using MediatR;
using UserManagement.Domain.Commands;
using UserManagement.Domain.Repositories;

namespace UserManagement.Core.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            user.Update(request.Name, request.Email);
            await _userRepository.UpdateAsync(user);
        }
    }
}
