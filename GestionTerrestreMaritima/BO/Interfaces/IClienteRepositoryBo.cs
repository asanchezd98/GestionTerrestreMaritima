using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;

namespace GestionTerrestreMaritima.BO.Interfaces
{
    public interface IClienteRepositoryBo
    {
        Task<List<ResponseCliente>> ObtenerClientes();
        void AddCLiente(RequestCliente request);
        int Login(RequestLogin request);
    }
}
