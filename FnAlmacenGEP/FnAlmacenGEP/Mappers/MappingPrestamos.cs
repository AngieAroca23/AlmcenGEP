using AutoMapper;
using FnAlmacenGEP.Models.DataTransferObjects;
using FnAlmacenGEP.Models.Input;

namespace FnAlmacenGEP.Mappers
{
    public class MappingPrestamos : Profile
    {
        public MappingPrestamos()
        {
            CreateMap<PrestamosDto, Prestamos>()
                .ForMember(dest => dest.IdPrestamo, opt => opt.MapFrom(src => src.id_prestamo))
                .ForMember(dest => dest.FechaPrestamo, opt => opt.MapFrom(src => src.fecha_prestamo.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.Herramienta, opt => opt.MapFrom(src => src.herramienta))
                .ForMember(dest => dest.EstadoEncuentra, opt => opt.MapFrom(src => src.estado_encuentra))
                .ForMember(dest => dest.NumDocPersonaRetira, opt => opt.MapFrom(src => src.documento_retira))
                .ForMember(dest => dest.NombrePersonaRetira, opt => opt.MapFrom(src => src.nombre_retira))
                .ForMember(dest => dest.NumDocPersonaEntrega, opt => opt.MapFrom(src => src.documento_entrega))
                .ForMember(dest => dest.NombrePersonaEntrega, opt => opt.MapFrom(src => src.nombre_entrega))
                .ForMember(dest => dest.FechaDevolucion, opt => opt.MapFrom(src => src.fecha_devolucion.Value.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.EstadoEntrega, opt => opt.MapFrom(src => src.estado_entrega))
                .ForMember(dest => dest.NumDocPersonaDevuelve, opt => opt.MapFrom(src => src.documento_devuelve))
                .ForMember(dest => dest.NombrePersonaDevuelve, opt => opt.MapFrom(src => src.nombre_devuelve))
                .ForMember(dest => dest.NumDocPersonaRecibe, opt => opt.MapFrom(src => src.documento_recibe))
                .ForMember(dest => dest.NombrePersonaRecibe, opt => opt.MapFrom(src => src.nombre_recibe))
                .ForMember(dest => dest.Observacion, opt => opt.MapFrom(src => src.observacion))
                .ForMember(dest => dest.Entregado, opt => opt.MapFrom(src => src.entregado))
                ;
        }
    }
}
