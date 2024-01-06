using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories;

public interface IPaymentRepository
{
    void Add(Payment Payment);

}