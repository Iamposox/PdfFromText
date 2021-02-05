using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using PdfFromText.BL;
using PdfFromText.BL.Interface;
using PdfFromText.Configuration;
using PdfFromText.Contract;

namespace PdfFromText.IoC {
    public class ServiceNinjectModule : NinjectModule{
        public override void Load() {
            var config = GetConfiguration<ServiceConfig>("ServiceConfig.json");

            Bind<ServiceConfig>().ToConstant(config);
            Bind<PdfService.PdfService.PdfServiceBase>().To<PdfFromTextService>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Bind<IPdfManager>().To<PdfManager>();
        }
        private TKey GetConfiguration<TKey>(string fileName) where TKey : new() {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder().AddJsonFile(fileName);
            IConfigurationRoot config = configBuilder.Build();
            var serviceConfig = new TKey();
            config.Bind(serviceConfig);
            return serviceConfig;
        }
    }
}
