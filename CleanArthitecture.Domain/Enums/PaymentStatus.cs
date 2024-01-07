using System.Text.Json.Serialization;

namespace CleanArthitecture.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Done = 1,
        Pending = 2,
        Failed = 3
    }
}
