using MediatR;
using Microsoft.Extensions.Configuration;
using UserManagement.Domain.Commands;

namespace UserManagement.Infrastructure.Messaging
{
    public class UserUpdateConsumer : BaseUserMessageConsumer
    {
        public UserUpdateConsumer(IMediator mediator, IConfiguration configuration) : base("userUpdateQueue", mediator, configuration) { }

        protected override async Task ProcessMessageAsync(string message)
        {
            var command = System.Text.Json.JsonSerializer.Deserialize<UpdateUserCommand>(message);
            await _mediator.Send(command);
        }

        protected override string GetQueueName() => "userUpdateQueue";
    }
}
