using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class PaymentRepository(DBContextConnection dbContext) :
    GenericRepository<Payment>(dbContext), IPaymentRepository
{

}