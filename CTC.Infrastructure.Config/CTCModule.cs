using Autofac;
using CTC.Application.PaymentCommand;
using CTC.Domain.Models.PaymentModels;
using CTC.Domain.Services.CardToCardService;
using CTC.Infrastructure.Acl.Payments;

namespace CTC.Infrastructure.Config
{
    public class CTCModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentService>().As<IPaymentService>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<PaymentManagementFactory>().As<IPaymentManagementFactory>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PaymentCommandHandler>().As<IPaymentCommand>()
               .InstancePerLifetimeScope();

        }
    }
}