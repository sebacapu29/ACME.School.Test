using ACME.School.Domain.Services;

namespace ACME.School.Infrastructure.Gateways
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool ProcessPayment(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
