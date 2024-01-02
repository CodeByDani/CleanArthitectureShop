using CleanArthitecture.Application.Services.Address.Commands.AddAddress;
using CleanArthitecture.Presentation.DTO;
using Mapster;

namespace CleanArthitecture.Presentation.Mapping
{
    public class AddressMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<(AddressRequest, long), AddressCommand>()
                    .Map(dest => dest.CustomerId, src => src.Item2)
                    .Map(dest => dest, src => src.Item1);

            //config.NewConfig<(AddressRequest, long), AddressCommand>()
            //        .Map(dest => dest.CustomerId, src => src.Item2)
            //        .Map(dest => dest, src => src.Item1);
        }
    }
}
