namespace GestionTerrestreMaritima.Model.Reponse
{
    public class ResponseCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Usuario { get; set; } = null!;
    }
}
