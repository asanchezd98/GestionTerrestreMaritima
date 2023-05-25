using System;
using System.Collections.Generic;

namespace GestionTerrestreMaritima.Model.Entity
{
    public partial class Bodega
    {
        public Bodega()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Disposicion { get; set; } = null!;
        public string Idfilial { get; set; } = null!;

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
