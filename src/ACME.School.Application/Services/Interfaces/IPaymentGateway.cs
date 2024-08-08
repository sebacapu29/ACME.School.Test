namespace ACME.School.Application.Services.Interfaces
{
    public interface IPaymentGateway
    {
        bool ProcessPayment(decimal amount);
    }
}
