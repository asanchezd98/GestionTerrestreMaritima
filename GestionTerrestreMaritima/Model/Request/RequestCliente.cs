using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GestionTerrestreMaritima.Model.Request
{
    /// <summary>
    /// Contrato del request cliente
    /// </summary>
    public class RequestCliente
    {
        /// <summary>
        /// Nombre cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Nombre es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres")]
        public string nombre { get; set; } = null!;

        /// <summary>
        /// Documento cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Documento es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo Documento no puede tener mas de 10 caracteres")]
        public string documento { get; set; } = null!;

        /// <summary>
        /// Telefono cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Telefono es requerido.")]
        [MaxLength(10, ErrorMessage = "El campo Telefono no puede tener mas de 10 caracteres")]
        public string telefono { get; set; } = null!;

        /// <summary>
        /// Usuario cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Usuario es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo Usuario no puede tener mas de 50 caracteres")]
        public string usuario { get; set; } = null!;

        /// <summary>
        /// Password cliente
        /// </summary>
        [Required(ErrorMessage = "El Campo Password es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo Password no puede tener mas de 50 caracteres")]
        public string password { get; set; } = null!;
    }
}
