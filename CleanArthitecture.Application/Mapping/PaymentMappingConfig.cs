using CleanArthitecture.Application.Services.OrderItem.Commands.AddRangeOrderItem;
using CleanArthitecture.Application.Services.Payment.Commands;
using Mapster;

namespace CleanArthitecture.Application.Mapping;

public class PaymentMappingConfig:IRegister
{
    public void Register(TypeAdapterConfig config)
    {

        config.NewConfig<AddPaymentCommand, Domain.Entities.Payment>()
            .Map(dest => dest.PaymentDate, src => src.DateTime)
            .Map(dest => dest.PaymentStatus, src => src.Status);
    }
}