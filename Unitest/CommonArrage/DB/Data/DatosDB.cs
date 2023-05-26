using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using Unitest.CommonArrage.DB.Data;

namespace XUnitTest.CommonArrange.DB.Data
{
    public class DatosDB
    {
        public GESTIONENVIOTMContext ContextoCargado { get; }

        public DatosDB(GESTIONENVIOTMContext dbContexto)
        {
            ContextoCargado = dbContexto;
        }

        /// <summary>
        /// Inicializa la BD in Memory 
        /// </summary>

        public void Bodegas()
        {
            ContextoCargado.Bodegas.Add(new Bodega
            {
                Disposicion = "NACIONAL",
                Id = 1,
                Nombre = "BODEGAORTEGA",
                Idfilial = "TRRT"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.Bodegas.Add(new Bodega
            {
                Disposicion = "INTERNACIONAL",
                Id = 2,
                Nombre = "BODEGAMAX",
                Idfilial = "MRTM"
            });
            ContextoCargado.SaveChanges();
        }

        public void Clientes()
        {
            ContextoCargado.Clientes.Add(new Cliente
            {
                Documento = "000000",
                Id = 1,
                Nombre = "Pacurita",
                Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                Telefono = "12345",
                Usuario = "gama"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.Clientes.Add(new Cliente
            {
                Documento = "000000",
                Id = 2,
                Nombre = "Pacurita",
                Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacf",
                Telefono = "12345",
                Usuario = "gama"
            });
            ContextoCargado.SaveChanges();
        }

        public void Productos()
        {
            ContextoCargado.Productos.Add(new Producto
            {
                Id = 1,
                Nombre = "ALIMENTOS"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.Productos.Add(new Producto
            {
                Id = 2,
                Nombre = "TECNOLOGIA"
            });
            ContextoCargado.SaveChanges();
        }

        public void Parametro()
        {
            ContextoCargado.ParametroTest.Add(new ParametroTest
            { 
                Id = 1,
                Nombreparametro = "FILIAL",
                Valorparametro = "MARITIMA",
                Idfilial = "MRTM"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 2,
                Nombreparametro = "FILIAL",
                Valorparametro = "TERRESTRE",
                Idfilial = "TRRT"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 3,
                Nombreparametro = "DISPOSICION",
                Valorparametro = "NACIONAL",
                Idfilial = "MRTM"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 4,
                Nombreparametro = "DISPOSICION",
                Valorparametro = "INTERNACIONAL",
                Idfilial = "MRTM"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 5,
                Nombreparametro = "DISPOSICION",
                Valorparametro = "NACIONAL",
                Idfilial = "TRRT"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 6,
                Nombreparametro = "DISPOSICION",
                Valorparametro = "INTERNACIONAL",
                Idfilial = "TRRT"
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.ParametroTest.Add(new ParametroTest
            {
                Id = 7,
                Nombreparametro = "TOKEN",
                Valorparametro = "Q3VhbHF1aWVyIGNvc2EsIGN1YWxxdWllciBjb3NhIHF1ZSBQYWkgTWVpIGRpZ2EsIG9iZWRlY2UuIFNpIGxlIGVjaGFzLCBhw7puIHBvciB1biBpbnN0YW50ZSB1biBvam8gZGVzYWZpYW50ZSwgdGUgbG8gYXJyYW5jYXLDoS4=",
                Idfilial = "TRRT"
            });
            ContextoCargado.SaveChanges();
        }

        public void Envio()
        {
            ContextoCargado.Envios.Add(new Envio
            {
                Id = 1,
                Cantproducto = 10,
                Descuento = 0,
                Fechaentrega = DateTime.Now,
                Fecharegistro = DateTime.Now,
                Filial = "MARITIMA",
                Idbodega = 1,
                Idcliente = 1,
                Idtipoproducto = 1,
                Numguia = "XOVsGi2KwE",
                Numtransporte = "FPP6304A",
                Precioenvio = 1000
            });
            ContextoCargado.SaveChanges();

            ContextoCargado.Envios.Add(new Envio
            {
                Id = 2,
                Cantproducto = 9,
                Descuento = 0,
                Fechaentrega = DateTime.Now,
                Fecharegistro = DateTime.Now,
                Filial = "TERRESTRE",
                Idbodega = 2,
                Idcliente = 1,
                Idtipoproducto = 2,
                Numguia = "OPFcLm1RmK",
                Numtransporte = "WAD3709Q",
                Precioenvio = 12000
            });
            ContextoCargado.SaveChanges();
        }

    }
}
