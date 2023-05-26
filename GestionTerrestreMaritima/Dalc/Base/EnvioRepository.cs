using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.Dalc.Base
{
    public class EnvioRepository
    {
        private readonly GESTIONENVIOTMContext _context;
        public EnvioRepository(GESTIONENVIOTMContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Envio>> ObtenerEntregas()
        {
            return _context.Envios.ToListAsync();
        }

        public void addEntrega(Envio entregamaritima)
        {
            try
            {
                _context.Envios.Add(entregamaritima);
                _context.SaveChanges();
            }catch (Exception ex)
            {

            }
            
        }
    }
}
