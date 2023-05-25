using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.Dalc.Base
{
    public class BodegaRepository
    {
        private readonly GESTIONENVIOTMContext _context;
        public BodegaRepository(GESTIONENVIOTMContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Bodega>> ObtenerBodegas()
        {
            return _context.Bodegas.ToListAsync();
        }
    }
}
