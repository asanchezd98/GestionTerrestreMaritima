using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.Dalc.Base
{
    public class ProductosRepository
    {
        private readonly GESTIONENVIOTMContext _context;
        public ProductosRepository(GESTIONENVIOTMContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Producto>> ObtenerProductos()
        {
            return _context.Productos.ToListAsync();
        }
    }
}
