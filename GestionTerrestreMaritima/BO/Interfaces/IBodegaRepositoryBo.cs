using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;

namespace GestionTerrestreMaritima.BO.Interfaces
{
    public interface IBodegaRepositoryBo
    {
        Task<List<ResponseBodega>> ObtenerBodegas();
    }
}
