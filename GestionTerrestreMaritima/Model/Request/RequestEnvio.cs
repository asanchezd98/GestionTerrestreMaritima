using System.ComponentModel.DataAnnotations;

namespace GestionTerrestreMaritima.Model.Request
{
    public class RequestEnvio
    {
        /// <summary>
        /// Idcliente que hacer eferencia al modelo Cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Idcliente es requerido.")]
        public int Idcliente { get; set; }
        /// <summary>
        /// Idtipoproducto que hacer eferencia al modelo Producto
        /// </summary>
        [Required(ErrorMessage = "El Campo Idtipoproducto es requerido.")]
        public int Idtipoproducto { get; set; }
        /// <summary>
        /// Cantproducto Envio
        /// </summary>
        [Required(ErrorMessage = "El Campo Cantproducto es requerido.")]
        public int Cantproducto { get; set; }
        /// <summary>
        /// Fechaentrega Envio
        /// </summary>
        [Required(ErrorMessage = "El Campo Fechaentrega es requerido.")]
        public DateTime Fechaentrega { get; set; }
        /// <summary>
        /// Idbodega que hacer eferencia al modelo Bodega
        /// </summary>
        [Required(ErrorMessage = "El Campo Idbodega es requerido.")]
        public int Idbodega { get; set; }
        /// <summary>
        /// Precioenvio Envio
        /// </summary>
        [Required(ErrorMessage = "El Campo Precioenvio es requerido.")]
        public int Precioenvio { get; set; }
        /// <summary>
        /// Filial Envio
        /// </summary>
        [Required(ErrorMessage = "El Campo Filial es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo Filial no puede tener mas de 10 caracteres")]
        public string Filial { get; set; } = null!;
    }
}
