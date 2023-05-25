using System;
using System.Collections.Generic;

namespace GestionTerrestreMaritima.Model.Entity
{
    public partial class Envio
    {
        public int Id { get; set; }
        public int Idcliente { get; set; }
        public int Idtipoproducto { get; set; }
        public int Cantproducto { get; set; }
        public DateTime Fecharegistro { get; set; }
        public DateTime Fechaentrega { get; set; }
        public int Idbodega { get; set; }
        public int Precioenvio { get; set; }
        public int Descuento { get; set; }
        public string Filial { get; set; } = null!;
        public string Numtransporte { get; set; } = null!;
        public string Numguia { get; set; } = null!;

        public virtual Bodega IdbodegaNavigation { get; set; } = null!;
        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual Producto IdtipoproductoNavigation { get; set; } = null!;
    }
}
