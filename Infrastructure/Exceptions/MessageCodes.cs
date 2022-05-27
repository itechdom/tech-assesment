using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Exceptions
{
    public static class CommonStrings
    {
        public const string BadRequestStatusCode = "FEINT400";

        public const string GeneralExceptionStatusCode = "FEINT500";
        public const string GeneralErrorMessageAR = "الخدمة غير متوفرة الآن، يرجى المحاولة في وقت لاحق";
        public const string GeneralErrorMessageEN = "The service is not available now, please try again later";
    }

    public static class MessageCodes
    {
        public const string InCorrectData = "FEINT1102";
        public const string OutOfDistriputionRange = "FEINT1103";
        public const string FEAccessForbidden = "FEINT4030";
        public const string MTProxyError = "FEINT5031";
        public const string MTAccessDenied = "FEINT4031";
        public const string MTNoDataFound = "FEINT4041";
        public const string InValidShipmentNumber = "FEINT1104";
        public const string Wait = "FEINT1105";

    }

}
