using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;

namespace GestionTerrestreMaritima.BO.Interfaces
{
    public interface IEnvioRepositoryBo
    {
        Task<List<ResponseEnvio>> ObtenerEnvios();
        bool addEnvio(RequestEnvio request);
    }
}
