using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justice_technical_assestment.Infrastructure.Exceptions
{
    public interface IErrorMessageService
    {
        public Task<IErrorMessage> GetErrorMessageByStatusCode(string StatusCode);
    }
}
