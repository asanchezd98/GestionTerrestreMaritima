using System;
using System.Collections.Generic;

namespace GestionTerrestreMaritima.Model.Entity
{
    public partial class Cliente
    {
        public Cliente()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
