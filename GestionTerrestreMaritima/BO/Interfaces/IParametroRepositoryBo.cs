using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;

namespace GestionTerrestreMaritima.BO.Interfaces
{
    public interface IParametroRepositoryBo
    {
        Task<List<ResponseParametro>> ObtenerParametrosxNombre(string nombre);
        Task<List<ResponseParametro>> ObtenerParametrosxfiltro(string parametro, string idFilial);
    }
}
