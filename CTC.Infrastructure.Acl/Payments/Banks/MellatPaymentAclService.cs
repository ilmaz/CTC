using CTC.Domain.Models.PaymentModels;
namespace CTC.Infrastructure.Acl.Payments.Banks
{
    public class MellatPaymentAclService : IPaymentPanagementAclService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private MellatPaymentAclService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public static MellatPaymentAclService New(IHttpClientFactory httpClientFactory) => new(httpClientFactory);

        public async Task<Payment> Payment(Payment payment)
        {
            //var httpClient = _httpClientFactory.CreateClient(Guid.NewGuid().ToString());
            //var circuitBreakerPolicy=  PollyPolicyBuilder.New().Build();
            //var httpResponseMessage = await
            //circuitBreakerPolicy.ExecuteAsync(
            //() => httpClient.PostAsync(url, content));


            await Task.Delay(1000);

            payment.SetResponce(100, "", "123ddf", 638205532192726284);

            return payment;
        }
    }
}
