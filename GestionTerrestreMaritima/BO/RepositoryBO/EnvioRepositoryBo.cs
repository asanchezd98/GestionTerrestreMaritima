using GestionTerrestreMaritima.BO.Interfaces;
using GestionTerrestreMaritima.Dalc.Base;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;

namespace GestionTerrestreMaritima.BO.RepositoryBO
{
    public class EnvioRepositoryBo : IEnvioRepositoryBo
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly EnvioRepository _envioRepository;
        private readonly ClienteRepositoryBo _clienteRepositoryBo;
        private readonly ProductosRepositoryBo _productosRepositoryBo;
        private readonly BodegaRepositoryBo _bodegaRepositoryBo;
        private readonly ParametroRepositoryBo _parametroRepositoryBo;
        public EnvioRepositoryBo(GESTIONENVIOTMContext context)
        {
            _context = context;
            _envioRepository = new EnvioRepository(context);
            _clienteRepositoryBo = new ClienteRepositoryBo(context);
            _productosRepositoryBo = new ProductosRepositoryBo(context);
            _bodegaRepositoryBo = new BodegaRepositoryBo(context);
            _parametroRepositoryBo = new ParametroRepositoryBo(context);
        }

        public async Task<List<ResponseEnvio>> ObtenerEnvios()
        {
            var response = new List<ResponseEnvio>();
            var data = await _envioRepository.ObtenerEntregas();
            foreach (var item in data)
            {
                var bodega = _bodegaRepositoryBo.ObtenerBodegas().Result.FirstOrDefault(x => x.Id == item.Idbodega);
                response.Add(new ResponseEnvio
                {
                    Id = item.Id,
                    Cliente = _clienteRepositoryBo.ObtenerClientes().Result.FirstOrDefault(x => x.Id == item.Idcliente).Nombre,
                    Producto = _productosRepositoryBo.ObtenerProductos().Result.FirstOrDefault(x => x.Id == item.Idtipoproducto).Nombre,
                    Cantproducto = item.Cantproducto,
                    Fecharegistro = item.Fecharegistro,
                    Fechaentrega = item.Fechaentrega,
                    Bodega = bodega.Nombre,
                    Disposicion = bodega.Disposicion,
                    Precioenvio = item.Precioenvio,
                    Descuento = item.Descuento,
                    Filial = item.Filial,
                    Numtransporte = item.Numtransporte,
                    Numguia = item.Numguia
                });
            }
            return response;
        }

        public bool addEnvio(RequestEnvio request)
        {
            try
            {
                var a = _parametroRepositoryBo.ObtenerParametrosxfiltro("FILIAL", request.Filial).Result.FirstOrDefault().Valorparametro;
                var s = new Utiles.Utiles(_context).generarNiVehiculo(request.Filial);
                var Numguia = new Utiles.Utiles(_context).GenerarCadenaAlfanumerica();
                var envio = new Envio
                {
                    Idcliente = request.Idcliente,
                    Idtipoproducto = request.Idtipoproducto,
                    Cantproducto = request.Cantproducto,
                    Fecharegistro = DateTime.Now,
                    Fechaentrega = request.Fechaentrega,
                    Idbodega = request.Idbodega,
                    Precioenvio = request.Precioenvio,
                    Descuento = request.Cantproducto > 10 ? (int)(request.Precioenvio - (request.Precioenvio * 0.03)) : 0,
                    Filial = _parametroRepositoryBo.ObtenerParametrosxfiltro("FILIAL", request.Filial).Result.FirstOrDefault().Valorparametro,
                    Numtransporte = new Utiles.Utiles(_context).generarNiVehiculo(request.Filial),
                    Numguia = new Utiles.Utiles(_context).GenerarCadenaAlfanumerica()
                };
                _envioRepository.addEntrega(envio);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
