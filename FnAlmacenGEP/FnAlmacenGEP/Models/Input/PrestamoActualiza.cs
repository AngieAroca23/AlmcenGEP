using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;

namespace FnAlmacenGEP.Models.Input
{
    public class PrestamoActualiza
    {
        [JsonProperty("idPrestamo")]
        [OpenApiProperty(Description = "Identificador del prestamo.")]
        public int IdPrestamo { get; set; }

        [JsonProperty("IdEstadoEntrega")]
        [OpenApiProperty(Description = "Identificador estado en el que se entrega.")]
        public int IdEstadoEntrega { get; set; }

        [JsonProperty("idPersonaDevuelve")]
        [OpenApiProperty(Description = "Identificador de la persona que devuelve.")]
        public int IdPersonaDevuelve { get; set; }

        [JsonProperty("idPersonaRecibe")]
        [OpenApiProperty(Description = "Identificador de la persona que recibe.")]
        public int IdPersonaRecibe { get; set; }

        [JsonProperty("observacion")]
        [OpenApiProperty(Description = "Observaciones del prestamo.")]
        public string Observacion { get; set; }

        [JsonProperty("entregado")]
        [OpenApiProperty(Description = "Especificación de entregado.")]
        public bool? Entregado { get; set; }

        [JsonProperty("fechaDevolucion")]
        [OpenApiProperty(Description = "Fecha de devolución.")]
        public DateTime? FechaDevolucion { get; set; }
    }
}
