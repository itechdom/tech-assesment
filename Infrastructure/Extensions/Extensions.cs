using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using justice_technical_assestment.Infrastructure.Exceptions;
using justice_technical_assestment.Models;

namespace justice_technical_assestment.Infrastructure.Extensions
{
    public static class Extensions
    {
        #region Exception handling

        public static IActionResult FormatModelStateToGenericResponseResult(this ActionContext context)
        {
            var _erroMessageService = (IErrorMessageService)context.HttpContext.RequestServices.GetService(typeof(IErrorMessageService));
            var errorTask = _erroMessageService.GetErrorMessageByStatusCode(CommonStrings.BadRequestStatusCode);
            errorTask.Wait();
            var error = errorTask.Result;

            var ResponseResult = new ResponseResult<string>();
            foreach (var modelStateEntry in context.ModelState)
            {
                foreach (var e in modelStateEntry.Value.Errors)
                {
                    ResponseResult.GenericResult.StatusCode = error.StatusCode;
                    ResponseResult.GenericResult.UserFriendlyEnglishMessage = error.MessgeEN;
                    ResponseResult.GenericResult.UserFriendlyArabicMessage = error.MessgeAR;
                    ResponseResult.GenericResult.TechnicalErrorMessage = e.ErrorMessage + " :" + modelStateEntry.Key;
                    break;
                }

                break;
            }

            var result = new BadRequestObjectResult(ResponseResult);
            result.ContentTypes.Add(MediaTypeNames.Application.Json);
            return result;
        }

        #endregion
    }
}
