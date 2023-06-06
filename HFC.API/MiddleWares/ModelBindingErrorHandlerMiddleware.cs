

// using System.Net;
// using System.Text;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// using Newtonsoft.Json;
// using System;

// namespace HFC.API.Middleware
// {
//     public class ModelBindingErrorHandlerMiddleware
//     {
//         private readonly RequestDelegate _next;

//         public ModelBindingErrorHandlerMiddleware(RequestDelegate next)
//         {
//             _next = next;
//         }

//         public async Task InvokeAsync(HttpContext context)
//         {
//             var originalBodyStream = context.Response.Body;

//             try
//             {
//                 using (var responseBody = new System.IO.MemoryStream())
//                 {
//                     context.Response.Body = responseBody;

//                     await _next(context);

//                     if (context.Response.StatusCode == StatusCodes.Status400BadRequest &&
//                         context.Response.ContentType == "application/problem+json; charset=utf-8")
//                     {
//                         Console.WriteLine("Hello world");

//                         await HandleValidationErrorResponseAsync(context);
//                     }
//                     else
//                     {
//                         await responseBody.CopyToAsync(originalBodyStream);
//                     }
//                 }
//             }
//             finally
//             {


//                 context.Response.Body = originalBodyStream;
//             }
//         }

//         private async Task HandleValidationErrorResponseAsync(HttpContext context)
//         {
//             var problemDetails = await ParseProblemDetailsAsync(context);

//             if (problemDetails is ValidationProblemDetails validationProblem)
//             {
//                 var errors = validationProblem.Errors
//                     .SelectMany(x => x.Value)
//                     .ToArray();

//                 var result = new
//                 {
//                     isSuccess = false,
//                     value = new object(),
//                     error = errors.FirstOrDefault() ?? "Validation error"
//                 };

//                 var json = JsonConvert.SerializeObject(result, Formatting.Indented);

//                 context.Response.StatusCode = (int)HttpStatusCode.Conflict;
//                 context.Response.ContentType = "application/json";

//                 await using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
//                 {
//                     await stream.CopyToAsync(context.Response.BodyWriter.AsStream());
//                 }
//             }
//         }




//         private async Task<ProblemDetails> ParseProblemDetailsAsync(HttpContext context)
//         {
//             context.Response.Body.Seek(0, SeekOrigin.Begin);
//             var responseContent = await new StreamReader(context.Response.Body).ReadToEndAsync();

//             try
//             {
//                 var serializerSettings = new JsonSerializerSettings
//                 {
//                     NullValueHandling = NullValueHandling.Ignore,
//                     MissingMemberHandling = MissingMemberHandling.Ignore
//                 };

//                 var problemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent, serializerSettings);



//                 return problemDetails ?? new ProblemDetails();
//             }
//             catch (Exception)
//             {
//                 return new ProblemDetails();
//             }
//         }


//     }
// }
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HFC.API.Middleware
{
    public class ValidationErrorResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationErrorResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBody = context.Response.Body;
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);

                    if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest &&
                        context.Response.ContentType == "application/problem+json; charset=utf-8")
                    {
                        await HandleValidationErrorResponseAsync(context);
                    }
                    else
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBody);
                    }
                }
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }

        private async Task HandleValidationErrorResponseAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var problemDetails = await ParseProblemDetailsAsync(context);
            var errorResponse = new
            {
                isSuccess = false,
                value = (object)null,
                error = "Validation error"
            };

            var json = JsonConvert.SerializeObject(errorResponse);
            var jsonBytes = Encoding.UTF8.GetBytes(json);
            await context.Response.Body.WriteAsync(jsonBytes, 0, jsonBytes.Length);
        }

        private async Task<ValidationProblemDetails> ParseProblemDetailsAsync(HttpContext context)
        {
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseContent = await new StreamReader(context.Response.Body).ReadToEndAsync();

            try
            {
                return JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
