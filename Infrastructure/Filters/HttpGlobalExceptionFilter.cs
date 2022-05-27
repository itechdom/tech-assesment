using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using justice_technical_assestment.Infrastructure.Exceptions;
using justice_technical_assestment.Models;

namespace justice_technical_assestment.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public IErrorMessageService _ErrorMessageService { get; }
        public HttpGlobalExceptionFilter(IErrorMessageService errorMessageService)
        {
            _ErrorMessageService = errorMessageService;
        }

        public void OnException(ExceptionContext context)
        {
            var _result = new ResponseResult<string>();

            if (context.Exception.GetType() == typeof(CustomException))
            {
                CustomException ex = (CustomException)context.Exception;

                if (string.IsNullOrEmpty(ex.FriendlyMessageAR))
                {
                    var task = _ErrorMessageService.GetErrorMessageByStatusCode(ex.Code);
                    task.Wait();
                    var errorMessge = task.Result;

                    _result.GenericResult = new Genericresult()
                    {
                        StatusCode = ex.Code,
                        UserFriendlyEnglishMessage = errorMessge?.MessgeEN ?? ex.Code,
                        UserFriendlyArabicMessage = errorMessge?.MessgeAR ?? ex.Code,
                        TechnicalErrorMessage = ex.TechnicalMessage ?? ex.ToString()
                    };
                }
                else
                    _result.GenericResult = new Genericresult()
                    {
                        StatusCode = ex.Code,
                        UserFriendlyEnglishMessage = ex.FriendlyMessageEN,
                        UserFriendlyArabicMessage = ex.FriendlyMessageAR,
                        TechnicalErrorMessage = ex.TechnicalMessage ?? ex.ToString()
                    };

                context.Result = new BadRequestObjectResult(_result);

                if (ex.Code == MessageCodes.MTProxyError)
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if (ex.Code == MessageCodes.MTAccessDenied || ex.Code == MessageCodes.FEAccessForbidden)
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                if (ex.Code == MessageCodes.MTNoDataFound)
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                else
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var ex = context.Exception;
                // Serilog.Log.Fatal(ex, ex.Message);

                //
                var task = _ErrorMessageService.GetErrorMessageByStatusCode(CommonStrings.GeneralExceptionStatusCode);
                task.Wait();
                var errorMessge = task.Result;

                _result.GenericResult = new Genericresult()
                {
                    StatusCode = ex.Message,
                    UserFriendlyEnglishMessage = errorMessge?.MessgeEN ?? ex.Message,
                    UserFriendlyArabicMessage = errorMessge?.MessgeAR ?? ex.Message,
                    TechnicalErrorMessage = ex.ToString()
                };

                context.Result = new JsonResult(_result);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}
