using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionTerrestreMaritima.Dalc.Base
{
    public class ClienteRepository
    {
        private readonly GESTIONENVIOTMContext _context;
        public ClienteRepository(GESTIONENVIOTMContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Cliente>> ObtenerClientes()
        {
            return _context.Clientes.ToListAsync();
        }

        public void AddCLiente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }catch (Exception ex) { }

            
        }

        public int Login(string usuario, string password)
        {
            var encryPassword = new Utiles.Utiles(_context).EncryptSHA256(password);
            var user = (from c in _context.Clientes where c.Usuario == usuario && c.Password == encryPassword select c).FirstOrDefault();
            return user != null ? user.Id : 0;
        }
    }
}
