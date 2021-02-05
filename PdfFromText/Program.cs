using NLog;
using System;
using System.Threading.Tasks;
using Grpc.Core;
using Ninject;
using PdfFromText.Configuration;
using PdfFromText.IoC;

namespace PdfFromText {
    public class Program {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        public static async Task Main() {
            try {
                var kernel = new StandardKernel(new ServiceNinjectModule());
                var serviceConfig = kernel!.Get<ServiceConfig>();

                var service = kernel!.Get<PdfService.PdfService.PdfServiceBase>();
                var server = new Server {
                    Services = {PdfService.PdfService.BindService(service)},
                    Ports = {
                        new ServerPort(serviceConfig.ServiceHost, serviceConfig.ServicePort, ServerCredentials.Insecure)
                    }
                };
                server.Start();

                _logger.Info($"Started at {serviceConfig.ServiceHost}:{serviceConfig.ServicePort}");
                var cancelTask = new TaskCompletionSource<bool>();
                Console.CancelKeyPress += (source, cancelArgs) => cancelTask.TrySetResult(true);
                await cancelTask.Task;

                await server.ShutdownAsync();
            }
            catch (Exception e) {
                _logger.Error(e);
            }
        }
    }
}
