using MediatR;
using UserManagement.Domain.Commands;

namespace UserManagement.Infrastructure.Messaging
{
    public class UserDeactivationConsumer : BaseUserMessageConsumer
    {
        public UserDeactivationConsumer(IMediator mediator) : base("userDeactivationQueue", mediator) { }

        protected override async Task ProcessMessageAsync(string message)
        {
            var command = System.Text.Json.JsonSerializer.Deserialize<DeactivateUserCommand>(message);
            await _mediator.Send(command);
        }

        protected override string GetQueueName() => "userDeactivationQueue";
    }
}
