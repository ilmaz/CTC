using Autofac;
using Microsoft.Extensions.DependencyInjection;

namespace CTC.Infrastructure.Acl.Helper
{
    internal class HttpClientHelper
    {
        private HttpClientHelper() { }

        public static IHttpClientFactory GetHttpClientFactory() {
            var builder = new ContainerBuilder();
            builder.Register(_ =>
            {
                var services = new ServiceCollection();
                services.AddHttpClient();
                var provider = services.BuildServiceProvider();
                return provider.GetRequiredService<IHttpClientFactory>();
            });

            return builder.Build().Resolve<IHttpClientFactory>();

        }
    }
}
