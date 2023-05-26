namespace CTC.Domain.Models.PaymentModels
{
    public interface IPaymentManagementFactory
    {
        IPaymentPanagementAclService GetInstance(string bankName);
    }
}
