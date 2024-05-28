using MediatR;
using Microsoft.Extensions.Configuration;
using UserManagement.Domain.Commands;

namespace UserManagement.Infrastructure.Messaging
{
    public class UserCreationConsumer : BaseUserMessageConsumer
    {
        public UserCreationConsumer(IMediator mediator, IConfiguration configuration) : base("userCreationQueue", mediator, configuration) { }

        protected override async Task ProcessMessageAsync(string message)
        {
            var command = System.Text.Json.JsonSerializer.Deserialize<CreateUserCommand>(message);
            await _mediator.Send(command);
        }

        protected override string GetQueueName() => "userCreationQueue";
    }
}
