using FnAlmacenGEP.Models.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FnAlmacenGEP.Interfaces
{
    public interface IDatabaseService
    {
        public Task<List<Prestamos>> GetPrestamos();
        public Task CreatePrestamos(PrestamoAdicion prestamos);
        public Task UpdatePrestamos(PrestamoActualiza prestamos);
    }
}
