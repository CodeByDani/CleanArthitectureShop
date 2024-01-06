using CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem;
using CleanArthitecture.Presentation.DTO;
using Mapster;

namespace CleanArthitecture.Presentation.Mapping
{
    public class OrderItemMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<HashSet<OrderRequest>, AddRangeOrderItemCommand>()
                    .Map(dest => dest.ProductId, src =>
                        new HashSet<long>(src.Select(o => o.ProductId)))
                    .Map(dest => dest.Quantity, src =>
                        src.Select(o => o.Quantity).ToList());
        }
    }
}
