using FnAlmacenGEP.Interfaces;
using FnAlmacenGEP.Models;
using FnAlmacenGEP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FnAlmacenGEP
{
    public class FnConsultaPrestamo
    {
        private readonly IDatabaseService _database;

        public FnConsultaPrestamo(IDatabaseService database)
        {
            _database = database;
        }

        [FunctionName("FnConsultaPrestamo")]
        [ExponentialBackoffRetry(3, "00:00:05", "00:05:00")]
        [OpenApiOperation(operationId: "ConsultaPrestamo", Description = "Función para consultar los prestamos.")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Description = "Respuesta exitosa.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")]
        public async Task<IActionResult> ConsultaPrestamo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "V1.0/ConsultaPrestamos")] HttpRequest req)
        {
            try
            {
                var resultConsulta = await _database.GetPrestamos();

                if (resultConsulta == null)
                    return HttpResponseHelper.HttpExplicitNoContent();

                return HttpResponseHelper.SuccessfulObjectResult(resultConsulta);
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message }); ;
            }
        }
    }
}

