namespace GestionTerrestreMaritima.Model.Reponse
{
    public class ResponseEnvio
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantproducto { get; set; }
        public DateTime Fecharegistro { get; set; }
        public DateTime Fechaentrega { get; set; }
        public string Bodega { get; set; }
        public string Disposicion { get; set; }
        public int Precioenvio { get; set; }
        public int? Descuento { get; set; }
        public string Filial { get; set; } = null!;
        public string Numtransporte { get; set; } = null!;
        public string Numguia { get; set; } = null!;
    }
}
