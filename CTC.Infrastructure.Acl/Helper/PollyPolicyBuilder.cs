using Polly;
using Polly.CircuitBreaker;
using Polly.Extensions.Http;
using System.Diagnostics;

namespace CTC.Infrastructure.Acl.Helper
{
    public class PollyPolicyBuilder
    {
        private PolicyBuilder<HttpResponseMessage> _policy;
        private PollyPolicyBuilder()
        {
            _policy = Policy
               .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
               .OrTransientHttpError();
        }

        public static PollyPolicyBuilder New()
        {
            return new PollyPolicyBuilder();
        }

        public AsyncCircuitBreakerPolicy<HttpResponseMessage> Build(double failureThreshold = 0.25, int samplingDuration = 60,
            int minimumThroughput = 7, int durationOfBreak = 30)
        {
            var samplingDurationTime = TimeSpan.FromSeconds(samplingDuration);
            var durationOfBreakTime = TimeSpan.FromSeconds(durationOfBreak);


            return _policy.AdvancedCircuitBreakerAsync(failureThreshold, samplingDurationTime,
                minimumThroughput, durationOfBreakTime, OnBreak, OnReset, OnHalfOpen);
        }

        private void OnHalfOpen()
        {
            Debug.Write("OnHalfOpen");
        }

        private void OnReset()
        {
            Debug.Write("OnReset");
        }

        private void OnBreak(DelegateResult<HttpResponseMessage> arg1, TimeSpan arg2)
        {
            Debug.Write("OnBreak");
        }
    }
}
