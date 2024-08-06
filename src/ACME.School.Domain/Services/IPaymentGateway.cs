namespace ACME.School.Domain.Services
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(decimal amount);
    }
}
