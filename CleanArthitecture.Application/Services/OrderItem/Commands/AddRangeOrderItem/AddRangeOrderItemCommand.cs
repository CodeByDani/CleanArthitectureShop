using MediatR;

namespace CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem;

public class AddRangeOrderItemCommand : IRequest
{
    public long CustomerId { get; set; }
    public long OrderId { get; set; }
    public HashSet<long> ProductId { get; set; }
    public List<int> Quantity { get; set; }
}