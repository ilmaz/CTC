using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Net.Http.Headers;

namespace ServiceHost.Helper
{
    public static class ExceptionHandlerHelper
    {
        public static IApplicationBuilder UseExceptionCustomHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(new ExceptionHandlerOptions
            {

                ExceptionHandler = (c) =>
                {
                    var exception = c.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exception.Error.GetType().Name switch
                    {
                        //TODO: Add Business Error
                        nameof(Exception) => HttpStatusCode.BadRequest,


                        _ => HttpStatusCode.InternalServerError
                    };
                    var contractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };

                    c.Response.ContentType = new MediaTypeHeaderValue("application/json").ToString();
                    c.Response.StatusCode = (int)statusCode;
                    var message = JsonConvert.SerializeObject(new List
                        <ErrorDetails>()
                            {
                                new ErrorDetails()
                                {
                                StatusCode = (int)statusCode,
                                Message = exception.Error.Message
                            }}, new JsonSerializerSettings
                            {
                                ContractResolver = contractResolver,
                                Formatting = Formatting.Indented
                            });

                    var content = Encoding.UTF8.GetBytes(message);
                    c.Response.Body.WriteAsync(content, 0, content.Length);

                    return Task.CompletedTask;
                }
            });
        }
    }
}
