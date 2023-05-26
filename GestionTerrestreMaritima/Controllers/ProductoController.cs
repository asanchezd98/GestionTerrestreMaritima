using GestionTerrestreMaritima.BO.RepositoryBO;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Reponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionTerrestreMaritima.Controllers
{
    /// <summary>
    /// Controller Api Parametro
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly ProductosRepositoryBo _repository;
        /// <summary>
        /// Contructor controller
        /// </summary>
        /// <param name="context"></param>
        public ProductoController(GESTIONENVIOTMContext context)
        {
            _context = context;
            _repository = new ProductosRepositoryBo(context);
        }

        /// <summary>
        /// Obtiene un listado de todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listarproductos")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseProducto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> listarClientes()
        {
            var reponse = new List<ResponseProducto>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                var data = await _repository.ObtenerProductos();
                foreach (var item in data)
                {
                    reponse.Add(new ResponseProducto
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }
    }
}
