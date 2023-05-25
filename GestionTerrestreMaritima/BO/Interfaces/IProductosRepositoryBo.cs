using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;

namespace GestionTerrestreMaritima.BO.Interfaces
{
    public interface IProductosRepositoryBo
    {
        Task<List<ResponseProducto>> ObtenerProductos();
    }
}
