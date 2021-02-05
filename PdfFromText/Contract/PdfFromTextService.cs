using System;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using NLog;
using PdfFromText.BL.Interface;
using PdfService;

namespace PdfFromText.Contract {
    public class PdfFromTextService : PdfService.PdfService.PdfServiceBase {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly IPdfManager _pdfManager;
        public PdfFromTextService(IPdfManager pdfManager) => _pdfManager = pdfManager;

        public override async Task<Result> Add(ObjectData data, ServerCallContext context) {
            return await SafetyExec(async () => {
                _pdfManager.CreatePdfAsync();
                return new Result {IsSuccess = true};
            }, data);
        }

        private static async Task<T> SafetyExec<T, TRequest>(Func<Task<T>> func, TRequest request) {
            try {
                return await func();
            }
            catch (Exception ex) {
                _logger.Error(ex, JsonConvert.SerializeObject(request));
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
