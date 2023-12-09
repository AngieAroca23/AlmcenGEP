using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;

namespace FnAlmacenGEP.Models.Input
{
    public class PrestamoAdicion
    {
        [JsonProperty("idHerramienta")]
        [OpenApiProperty(Description = "Identificador de la herramienta.")]
        public int IdHerramienta { get; set; }

        [JsonProperty("idEstadoEncuentra")]
        [OpenApiProperty(Description = "Identificador estado en el que se encuentra.")]
        public int IdEstadoEncuentra { get; set; }

        [JsonProperty("idPersonaRetira")]
        [OpenApiProperty(Description = "Identificador de la persona que retira.")]
        public int IdPersonaRetira { get; set; }

        [JsonProperty("idPersonaEntrega")]
        [OpenApiProperty(Description = "Identificador de la persona que entrega.")]
        public int IdPersonaEntrega { get; set; }

        [JsonProperty("observacion")]
        [OpenApiProperty(Description = "Observaciones del prestamo.")]
        public string Observacion { get; set; }
    }
}
