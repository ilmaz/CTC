using CTC.Domain.Models.PaymentModels;
using CTC.Infrastructure.Acl.Helper;
using CTC.Infrastructure.Acl.Payments.Banks;

namespace CTC.Infrastructure.Acl.Payments
{
    public class PaymentManagementFactory : IPaymentManagementFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentManagementFactory()
        {

            _httpClientFactory = HttpClientHelper.GetHttpClientFactory();

        }
        public static PaymentManagementFactory New() => new();
        public IPaymentPanagementAclService GetInstance(string bankName)
        {
            return bankName.ToLower() switch
            {
                "mellat" => MellatPaymentAclService.New(_httpClientFactory),
                "saderat" => SaderatPaymentAclService.New(_httpClientFactory),
                _ => AyandehPaymentAclService.New(_httpClientFactory),
            };
        }
    }
}
