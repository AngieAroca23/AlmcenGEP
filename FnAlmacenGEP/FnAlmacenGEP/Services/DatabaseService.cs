using AutoMapper;
using Dapper;
using FnAlmacenGEP.DataContext;
using FnAlmacenGEP.Interfaces;
using FnAlmacenGEP.Models.DataTransferObjects;
using FnAlmacenGEP.Models.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FnAlmacenGEP.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DapperContext _context;
        private readonly IMapper _mapper;

        public DatabaseService(DapperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Prestamos>> GetPrestamos()
        {
            using IDbConnection db = _context.CreateConnection();

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"SELECT p.id_prestamo, p.fecha_prestamo, h.herramienta, eh.tipo_estado estado_encuentra,
                                    ppr.numero_documento documento_retira, ppr.nombres + ' ' + ppr.apellidos nombre_retira, 
                                    ppe.numero_documento documento_entrega, ppe.nombres + ' ' + ppe.apellidos nombre_entrega,
                                    p.fecha_devolucion, ehe.tipo_estado estado_entrega, 
                                    ppd.numero_documento documento_devuelve, ppd.nombres + ' ' + ppd.apellidos nombre_devuelve,
                                    ppre.numero_documento documento_recibe, ppre.nombres + ' ' + ppre.apellidos nombre_recibe,
                                    p.observacion, p.entregado
                                    FROM dbo.prestamos p
                                    INNER JOIN dbo.herramientas h ON p.id_herramienta = h.id_herramienta
                                    INNER JOIN dbo.persona_prestamos ppr ON p.id_persona_retira = ppr.id_persona_prestamo
                                    INNER JOIN dbo.persona_prestamos ppe ON p.id_persona_entrega = ppe.id_persona_prestamo
                                    LEFT JOIN dbo.persona_prestamos ppd ON p.id_persona_devulve = ppd.id_persona_prestamo
                                    LEFT JOIN dbo.persona_prestamos ppre ON p.id_persona_recibe = ppre.id_persona_prestamo
                                    INNER JOIN dbo.estado_herramienta eh ON p.id_estado_encuentra = eh.id_estado
                                    LEFT JOIN dbo.estado_herramienta ehe ON p.id_estado_entrega = ehe.id_estado";

                var resultDto = await db.QueryAsync<PrestamosDto>(sqlQuery);
                return _mapper.Map<List<Prestamos>>(resultDto);
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public async Task CreatePrestamos(PrestamoAdicion prestamos)
        {
            using IDbConnection db = _context.CreateConnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"INSERT INTO dbo.prestamos
                                    (id_herramienta,id_persona_retira,id_persona_entrega,id_estado_encuentra,observacion,fecha_prestamo)
                                    VALUES (@id_herramienta, @id_persona_retira, @id_persona_entrega, @id_estado_encuentra,@observacion,
                                    @fecha_prestamo)";

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("id_herramienta", prestamos.IdHerramienta, DbType.Int32);
                parameter.Add("id_persona_retira", prestamos.IdPersonaRetira, DbType.Int32);
                parameter.Add("id_persona_entrega", prestamos.IdPersonaEntrega, DbType.Int32);
                parameter.Add("id_estado_encuentra", prestamos.IdEstadoEncuentra, DbType.Int32);
                parameter.Add("observacion", prestamos.Observacion, DbType.String);
                parameter.Add("fecha_prestamo", DateTime.UtcNow, DbType.DateTime);

                await db.ExecuteAsync(sqlQuery, parameter);
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public async Task UpdatePrestamos(PrestamoActualiza prestamos)
        {
            using IDbConnection db = _context.CreateConnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"UPDATE dbo.prestamos SET 
                                    id_persona_recibe = @id_persona_recibe, 
                                    id_persona_devulve = @id_persona_devulve, 
                                    observacion = @observacion, 
                                    fecha_devolucion = @fecha_devolucion, 
                                    entregado = @entregado
                                    WHERE id_prestamo = @id_prestamo";

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("id_persona_recibe", prestamos.IdPersonaRecibe, DbType.Int32);
                parameter.Add("id_persona_devulve", prestamos.IdPersonaDevuelve, DbType.Int32);
                parameter.Add("observacion", prestamos.Observacion, DbType.String);
                parameter.Add("fecha_devolucion", prestamos.FechaDevolucion, DbType.DateTime);
                parameter.Add("entregado", prestamos.Entregado, DbType.Boolean);
                parameter.Add("id_prestamo", prestamos.IdPrestamo, DbType.Int32);

                await db.ExecuteAsync(sqlQuery, parameter);
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }
    }
}
