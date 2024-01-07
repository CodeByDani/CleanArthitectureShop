using CleanArthitecture.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CleanArthitecture.Presentation.DTO;

public record PaymentRequest(
    long OrderId,
    PaymentStatus Status
    );