using GestionTerrestreMaritima.BO.RepositoryBO;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Reponse;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionTerrestreMaritima.Controllers
{
    /// <summary>
    /// Controller Api Bodega
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly BodegaRepositoryBo _repository;
        /// <summary>
        /// Contructor controller
        /// </summary>
        /// <param name="context"></param>
        public BodegaController(GESTIONENVIOTMContext context)
        {
            _context = context;
            _repository = new BodegaRepositoryBo(context);
        }

        /// <summary>
        /// Obtiene un listado de todas las bodegas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listarbodegas")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseBodega), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> listarBodegas()
        {
            var reponse = new List<ResponseBodega>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if(!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { Mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });
                reponse = await _repository.ObtenerBodegas();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { Mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }
    }
}
