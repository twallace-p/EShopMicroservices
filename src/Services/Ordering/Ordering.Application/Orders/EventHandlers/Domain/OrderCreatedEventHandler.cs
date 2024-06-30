namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event Handed: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
