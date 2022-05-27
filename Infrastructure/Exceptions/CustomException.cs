using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Exceptions
{
    public class CustomException : Exception
    {
        public string Code { get; }
        public string FriendlyMessageAR { get; }
        public string FriendlyMessageEN { get; }
        public string TechnicalMessage { get; }
        public Exception TechnicalDetails { get; }

        public CustomException(string code, Exception technicalException = null) :
            base(code, technicalException)
        {
            Code = code;
            TechnicalMessage = technicalException?.Message;
            TechnicalDetails = technicalException;
        }

        public CustomException(string code, string technicalMessage = null) :
          base(code)
        {
            Code = code;
            TechnicalMessage = technicalMessage;
        }

        public CustomException(string code, string friendlyMessageEN = null, string friendlyMessageAR = null, string technicalMessage = null) :
          base(code)
        {
            Code = code;
            FriendlyMessageAR = friendlyMessageAR;
            FriendlyMessageEN = friendlyMessageEN;
            TechnicalMessage = technicalMessage;
        }
    }
}
