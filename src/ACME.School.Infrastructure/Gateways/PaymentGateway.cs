using ACME.School.Application.Services.Interfaces;

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
