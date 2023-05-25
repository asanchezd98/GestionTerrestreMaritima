using GestionTerrestreMaritima.BO.RepositoryBO;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GestionTerrestreMaritima.Controllers
{
    /// <summary>
    /// Controller Api Envio
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly EnvioRepositoryBo _repository;

        /// <summary>
        /// Contructor controller
        /// </summary>
        /// <param name="context"></param>
        public EnvioController(GESTIONENVIOTMContext context)
        {
            _context = context;
            _repository = new EnvioRepositoryBo(context);
        }

        /// <summary>
        /// Agrega un Envio
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addenvio")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(RequestEnvio), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> addEnvio([FromBody] RequestEnvio request)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { Mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                if (request == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMensajeError { Mensaje = "ERROR: La petición no puede estar vacia.", code = (int)HttpStatusCode.BadRequest });

                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.UnprocessableEntity, new ResponseMensajeError
                    {
                        Mensaje = "ERROR: Contrato del modelo invalido. " + string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)),
                        code = (int)HttpStatusCode.UnprocessableEntity
                    });

                _repository.addEnvio(request);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { Mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok("Operacion Realizada con exicto!");
        }

        /// <summary>
        /// Obtiene un listado de todos las entregas Envio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listarenvio")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseEnvio), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerEnvios()
        {
            var reponse = new List<ResponseEnvio>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { Mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                reponse = await _repository.ObtenerEnvios();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { Mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }
    }
}
