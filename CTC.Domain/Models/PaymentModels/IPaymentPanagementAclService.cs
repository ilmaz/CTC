namespace CTC.Domain.Models.PaymentModels
{
    public interface IPaymentPanagementAclService
    {
        public Task<Payment> Payment(Payment payment);
    }
}
