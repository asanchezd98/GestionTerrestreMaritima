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
    public class ParametroController : ControllerBase
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly ParametroRepositoryBo _repository;
        /// <summary>
        /// Contructor controller
        /// </summary>
        /// <param name="context"></param>
        public ParametroController(GESTIONENVIOTMContext context)
        {
            _context = context;
            _repository = new ParametroRepositoryBo(context);
        }

        /// <summary>
        /// Obtiene un listado de parametros filtrados
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="idFilial"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listarParametrosxfiltro/parametro/{parametro}/idfilial/{idFilial}")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseParametro), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerParametrosxfiltro(string parametro, string idFilial)
        {
            var reponse = new List<ResponseParametro>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { Mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                reponse = await _repository.ObtenerParametrosxfiltro(parametro, idFilial);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { Mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }

        /// <summary>
        /// Obtiene un listado de parametros por nombre
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listarParametrosxfiltro/parametro/{parametro}")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseParametro), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerParametrosxfiltro(string parametro)
        {
            var reponse = new List<ResponseParametro>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { Mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                reponse = await _repository.ObtenerParametrosxNombre(parametro);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { Mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }
    }
}
