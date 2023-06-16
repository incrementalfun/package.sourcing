using MassTransit;

namespace Incremental.Common.Sourcing.Messaging;

internal class MessageBus : IMessageBus
{
    private readonly IPublishEndpoint _provider;

    public MessageBus(IPublishEndpoint provider)
    {
        _provider = provider;
    }
    
    public async Task Send<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage
    {
        await _provider.Publish(message, cancellationToken)
            .ConfigureAwait(false);
    }
}