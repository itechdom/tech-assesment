using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Exceptions
{
    public interface IErrorMessage
    {
        public string StatusCode { get; set; }
        public string MessgeEN { get; set; }
        public string MessgeAR { get; set; }
    }

    public class ErrorMessage : IErrorMessage
    {
        public ErrorMessage(string statusCode, string messgeEN, string messgeAR)
        {
            StatusCode = statusCode;
            MessgeEN = messgeEN;
            MessgeAR = messgeAR;
        }

        public string StatusCode { get; set; }
        public string MessgeEN { get; set; }
        public string MessgeAR { get; set; }
    }
}
