using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;

namespace FnAlmacenGEP.Models.Input
{
    public class Prestamos
    {
        [JsonProperty("idPrestamo")]
        [OpenApiProperty(Description = "Identificador del prestamo.")]
        public int IdPrestamo { get; set; }

        [JsonProperty("fechaPrestamo")]
        [OpenApiProperty(Description = "Fecha del prestamo.")]
        public DateTime FechaPrestamo { get; set; }

        [JsonProperty("herramienta")]
        [OpenApiProperty(Description = "Descripción de la herramienta.")]
        public string Herramienta { get; set; }

        [JsonProperty("estadoEncuentra")]
        [OpenApiProperty(Description = "Descripción estado en el que se encuentra.")]
        public string EstadoEncuentra { get; set; }

        [JsonProperty("numDocPersonaRetira")]
        [OpenApiProperty(Description = "Número de documento de la persona que retira.")]
        public int NumDocPersonaRetira { get; set; }

        [JsonProperty("nombrePersonaRetira")]
        [OpenApiProperty(Description = "Nombre de la persona que retira.")]
        public string NombrePersonaRetira { get; set; }

        [JsonProperty("numDocPersonaEntrega")]
        [OpenApiProperty(Description = "Número de documento de la persona que entrega.")]
        public int NumDocPersonaEntrega { get; set; }

        [JsonProperty("nombrePersonaEntrega")]
        [OpenApiProperty(Description = "Nombre de la persona que entrega.")]
        public string NombrePersonaEntrega { get; set; }

        [JsonProperty("fechaDevolucion")]
        [OpenApiProperty(Description = "Fecha de devolución.")]
        public DateTime? FechaDevolucion { get; set; }

        [JsonProperty("estadoEntrega")]
        [OpenApiProperty(Description = "Estado en el que se entrega.")]
        public string EstadoEntrega { get; set; }

        [JsonProperty("numDocPersonaDevuelve")]
        [OpenApiProperty(Description = "Número de documento de la persona que devuelve.")]
        public int? NumDocPersonaDevuelve { get; set; }

        [JsonProperty("nombrePersonaDevuelve")]
        [OpenApiProperty(Description = "Nombre de la persona que devuelve.")]
        public string NombrePersonaDevuelve { get; set; }

        [JsonProperty("numDocPersonaRecibe")]
        [OpenApiProperty(Description = "Número de documento de la persona que recibe.")]
        public int? NumDocPersonaRecibe { get; set; }

        [JsonProperty("nombrePersonaRecibe")]
        [OpenApiProperty(Description = "Nombre de la persona que recibe.")]
        public string NombrePersonaRecibe { get; set; }

        [JsonProperty("observacion")]
        [OpenApiProperty(Description = "Observaciones del prestamo.")]
        public string Observacion { get; set; }

        [JsonProperty("entregado")]
        [OpenApiProperty(Description = "Especificación de entregado.")]
        public bool? Entregado { get; set; }
    }
}
