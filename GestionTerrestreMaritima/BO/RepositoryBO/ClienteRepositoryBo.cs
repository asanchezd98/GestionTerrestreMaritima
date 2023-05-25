using GestionTerrestreMaritima.BO.Interfaces;
using GestionTerrestreMaritima.Dalc.Base;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.BO.RepositoryBO
{
    public class ClienteRepositoryBo : IClienteRepositoryBo
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly ClienteRepository _clienteRepository;
        public ClienteRepositoryBo(GESTIONENVIOTMContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<List<ResponseCliente>> ObtenerClientes()
        {
            var response = new List<ResponseCliente>();
            var data = await _clienteRepository.ObtenerClientes();
            foreach (var item in data)
            {
                response.Add(new ResponseCliente
                {
                    Documento = item.Documento,
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Telefono = item.Telefono,
                    Usuario = item.Usuario
                });
            }
            return response;
        }

        public void AddCLiente(RequestCliente request)
        {
            var cliente = new Cliente
            {
                Nombre = request.Nombre,
                Documento = request.Documento,
                Telefono = request.Telefono,
                Usuario = request.Usuario,
                Password = new Utiles.Utiles(_context).EncryptSHA256(request.Password)
            };
            _clienteRepository.AddCLiente(cliente);
        }

        public int Login(RequestLogin request)
        {
            return _clienteRepository.Login(request.Usuario, request.Paswword);
        }
    }
}
