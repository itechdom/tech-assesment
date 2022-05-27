using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using justice_technical_assestment.Infrastructure.Exceptions;
using justice_technical_assestment.Infrastructure.Repositories;

namespace justice_technical_assestment.Infrastructure.Services
{
    public class ErrorMessageService : IErrorMessageService
    {
        public IErrorMessageRepository _ErrorMessageRepository { get; }

        public ErrorMessageService(IErrorMessageRepository errorMessageRepository)
        {
            _ErrorMessageRepository = errorMessageRepository;
        }

        public async Task<IErrorMessage> GetErrorMessageByStatusCode(string StatusCode)
        {
            return await _ErrorMessageRepository.GetErrorMessageByStatusCode(StatusCode);
        }
    }
}
