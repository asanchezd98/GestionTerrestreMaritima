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
    /// Controller Api Cliente
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly GESTIONENVIOTMContext _context;
        private readonly ClienteRepositoryBo _repository;
        /// <summary>
        /// Contructor controller
        /// </summary>
        /// <param name="context"></param>
        public ClienteController(GESTIONENVIOTMContext context)
        {
            _context = context;
            _repository = new ClienteRepositoryBo(context);
        }

        /// <summary>
        /// Obtiene un listado de todos los clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listarclientes")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseCliente), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> listarClientes()
        {
            var reponse = new List<ResponseCliente>();
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                reponse = await _repository.ObtenerClientes();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError  { mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(reponse);
        }

        /// <summary>
        /// Agrega un cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addclientes")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(RequestCliente), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> addClientes([FromBody]RequestCliente request)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });
                
                if (request == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMensajeError { mensaje = "ERROR: La petición no puede estar vacia.", code = (int)HttpStatusCode.BadRequest });

                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.UnprocessableEntity, new ResponseMensajeError { mensaje = "ERROR: Contrato del modelo invalido. " + string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors)
        .               Select(e => e.ErrorMessage)), code = (int)HttpStatusCode.UnprocessableEntity });
                
                _repository.AddCLiente(request);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(new { mensaje = "Operacion Realizada con exicto!", code = 200});
        }

        /// <summary>
        /// Login cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseMensajeError), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ResponseMensajeLogin), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> login([FromBody] RequestLogin request)
        {
            var idCliente = 0;
            try
            {
                var token = Request.Headers["Authorization"].ToString();
                if (!new Utiles.Utiles(_context).ValidarToken(token))
                    return StatusCode((int)HttpStatusCode.Unauthorized, new ResponseMensajeError { mensaje = "ERROR: Token invalido.", code = (int)HttpStatusCode.Unauthorized });

                if (request == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMensajeError { mensaje = "ERROR: La petición no puede estar vacia.", code = (int)HttpStatusCode.BadRequest });

                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.UnprocessableEntity, new ResponseMensajeError
                    {
                        mensaje = "ERROR: Contrato del modelo invalido. " + string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)),
                        code = (int)HttpStatusCode.UnprocessableEntity
                    });

                idCliente = _repository.Login(request);
                if (idCliente == 0)
                    return StatusCode((int)HttpStatusCode.BadRequest, new ResponseMensajeError { mensaje = "ERROR: Usuario o contraseña incorrecta.!", code = (int)HttpStatusCode.BadRequest });

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseMensajeError { mensaje = $"ERROR: {ex.Message}.", code = (int)HttpStatusCode.InternalServerError });
            }
            return Ok(new ResponseMensajeLogin { Mensaje = "Operacion Realizada con exicto!",  IdCliente = idCliente });
        }
    }
}
