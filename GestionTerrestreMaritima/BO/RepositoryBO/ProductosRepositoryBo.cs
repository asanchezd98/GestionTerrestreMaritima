using GestionTerrestreMaritima.BO.Interfaces;
using GestionTerrestreMaritima.Dalc.Base;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;

namespace GestionTerrestreMaritima.BO.RepositoryBO
{
    public class ProductosRepositoryBo : IProductosRepositoryBo
    {
        private readonly ProductosRepository _productosRepository;
        public ProductosRepositoryBo(GESTIONENVIOTMContext context)
        {
            _productosRepository = new ProductosRepository(context);
        }

        public async Task<List<ResponseProducto>> ObtenerProductos()
        {
            var response = new List<ResponseProducto>();
            var data = await _productosRepository.ObtenerProductos();
            foreach (var item in data)
            {
                response.Add(new ResponseProducto
                {
                    Id = item.Id,
                    Nombre = item.Nombre
                });
            }
            return response;
        }
    }
}
