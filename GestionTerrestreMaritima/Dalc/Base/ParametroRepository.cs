using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.Dalc.Base
{
    public class ParametroRepository
    {
        private readonly GESTIONENVIOTMContext _context;
        public ParametroRepository(GESTIONENVIOTMContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Parametro>> ObtenerParametrosxNombre(string nombre)
        {
            return _context.Parametros.Where(x => x.Nombreparametro == nombre).Distinct().ToListAsync();
        }

        public Task<List<Parametro>> ObtenerParametrosxfiltro(string parametro, string idFilial)
        {
            return _context.Parametros.Where(x => x.Nombreparametro.ToUpper() == parametro.ToUpper() && x.Idfilial.ToUpper() == idFilial.ToUpper()).ToListAsync();
        }
    }
}
