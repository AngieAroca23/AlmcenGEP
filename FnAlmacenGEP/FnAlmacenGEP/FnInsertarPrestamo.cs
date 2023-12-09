using FnAlmacenGEP.Interfaces;
using FnAlmacenGEP.Models;
using FnAlmacenGEP.Models.Input;
using FnAlmacenGEP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FnAlmacenGEP
{
    public class FnInsertarPrestamo
    {
        private readonly IDatabaseService _database;

        public FnInsertarPrestamo(IDatabaseService database)
        {
            _database = database;
        }

        [FunctionName("FnInsertarPrestamo")]
        [ExponentialBackoffRetry(3, "00:00:05", "00:05:00")]
        [OpenApiOperation(operationId: "InsercionPrestamo", Description = "Función para insertar un prestamo.")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(PrestamoAdicion), Example = typeof(PrestamoAdicion))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Description = "Respuesta exitosa.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Respuesta de Creacion")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")]
        public async Task<IActionResult> InsercionPrestamo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "V1.0/InsertarPrestamos")] HttpRequest req)
        {
            var json = await req.ReadAsStringAsync();
            PrestamoAdicion request = JsonConvert.DeserializeObject<PrestamoAdicion>(json);

            try
            {
                await _database.CreatePrestamos(request);

                return HttpResponseHelper.Response(StatusCodes.Status200OK, new ResponseResult()
                {
                    IsError = false,
                    Message = "Prestamo realizado exitosamente."
                });
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
            }
        }
    }
}

