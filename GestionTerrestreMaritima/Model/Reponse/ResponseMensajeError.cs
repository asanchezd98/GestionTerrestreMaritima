﻿namespace GestionTerrestreMaritima.Model.Reponse
{
    /// <summary>
    /// Objeto para capturar el mensaje de error
    /// </summary>
    public class ResponseMensajeError
    {
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string mensaje { get; set; } 
        public int code { get; set; }
    }
}
