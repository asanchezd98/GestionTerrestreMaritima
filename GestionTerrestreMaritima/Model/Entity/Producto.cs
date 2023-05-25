using System;
using System.Collections.Generic;

namespace GestionTerrestreMaritima.Model.Entity
{
    public partial class Producto
    {
        public Producto()
        {
            Envios = new HashSet<Envio>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Envio> Envios { get; set; }
    }
}
