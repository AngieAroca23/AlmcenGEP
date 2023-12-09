using System;

namespace FnAlmacenGEP.Models.DataTransferObjects
{
    public class PrestamosDto
    {
        public int id_prestamo { get; set; }
        public DateTime fecha_prestamo { get; set; }
        public string herramienta { get; set; }
        public string estado_encuentra { get; set; }
        public int documento_retira { get; set; }
        public string nombre_retira { get; set; }
        public int documento_entrega { get; set; }
        public string nombre_entrega { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public string estado_entrega { get; set; }
        public int documento_devuelve { get; set; }
        public string nombre_devuelve { get; set; }
        public int documento_recibe { get; set; }
        public string nombre_recibe { get; set; }
        public string observacion { get; set; }
        public bool? entregado { get; set; }
    }
}
