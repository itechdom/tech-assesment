using justice_technical_assestment.Infrastructure.Exceptions;

namespace justice_technical_assestment.Infrastructure.Repositories
{
    public class InMemoryErrorMessageRepository : IErrorMessageRepository
    {
        private IEnumerable<IErrorMessage> _ErrorMessages { get; }
        public ILogger<InMemoryErrorMessageRepository> _Logger { get; }

        public InMemoryErrorMessageRepository(ILogger<InMemoryErrorMessageRepository> logger)
        {
            _ErrorMessages = new List<ErrorMessage>() {
                new ErrorMessage(MessageCodes.InCorrectData, "In Correct Data", "In Correct Data"),
                new ErrorMessage(MessageCodes.OutOfDistriputionRange, "Unfortunately, this address is outside the scope of distribution, please choose another default address, or register a new national address", "للأسف ، هذا العنوان خارج نطاق التوزيع ، فضلاً أختر وجهة وصول أخرى"),
                new ErrorMessage(MessageCodes.FEAccessForbidden, "Access Forbidden.", "Access Forbidden."),
                new ErrorMessage(MessageCodes.MTProxyError, "Error Consuming MT", "Error Consuming MT"),
                new ErrorMessage(MessageCodes.MTAccessDenied, "Access denied from MT", "Access denied from MT"),
                new ErrorMessage(MessageCodes.MTNoDataFound, "No Data Found", "No Data Found"),
                new ErrorMessage(MessageCodes.InValidShipmentNumber, "Invalid Shipment Number", "رقم الشحنة غير صحيح"),
                new ErrorMessage(MessageCodes.Wait, "Your request has been received. It may take 48 hours to process", "تم ارسال طلبك. سيتم معالجة الطلب خلال 48 ساعة." +
                ""),
            };

            _Logger = logger;
        }

        public async Task<IErrorMessage> GetErrorMessageByStatusCode(string StatusCode)
        {
            var er = _ErrorMessages.FirstOrDefault(i => i.StatusCode == StatusCode);

            if (er == null)
            {
                er = new ErrorMessage(StatusCode,
                    CommonStrings.GeneralErrorMessageEN,
                    CommonStrings.GeneralErrorMessageAR);

                _Logger.LogWarning($"========== StatusCode: {StatusCode} was not found ============");
            }

            return er;
        }

        public async Task<IEnumerable<IErrorMessage>> GetErrorMessages()
        {
            return _ErrorMessages;
        }
    }
}
