namespace GestionTerrestreMaritima.Model.Reponse
{
    public class ResponseBodega
    {
        /// <summary>
        /// Id Bodega
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre Bodega
        /// </summary>
        public string Nombre { get; set; } = null!;
        /// <summary>
        /// Disposicion Bodega
        /// </summary>
        public string Disposicion { get; set; } = null!;
        /// <summary>
        /// Idfilial Bodega
        /// </summary>
        public string Idfilial { get; set; } = null!;
    }
}
