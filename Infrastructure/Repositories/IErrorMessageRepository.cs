using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using justice_technical_assestment.Infrastructure.Exceptions;

namespace justice_technical_assestment.Infrastructure.Repositories
{
    public interface IErrorMessageRepository
    {
        public Task<IEnumerable<IErrorMessage>> GetErrorMessages();

        public Task<IErrorMessage> GetErrorMessageByStatusCode(string StatusCode);
    }
}
