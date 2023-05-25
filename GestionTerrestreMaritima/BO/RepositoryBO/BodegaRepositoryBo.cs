using GestionTerrestreMaritima.BO.Interfaces;
using GestionTerrestreMaritima.Dalc.Base;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;
using Microsoft.EntityFrameworkCore;

namespace GestionTerrestreMaritima.BO.RepositoryBO
{
    public class BodegaRepositoryBo : IBodegaRepositoryBo
    {
        private readonly BodegaRepository _bodegaRepository;
        public BodegaRepositoryBo(GESTIONENVIOTMContext context)
        {
            _bodegaRepository = new BodegaRepository(context);
        }

        public async Task<List<ResponseBodega>> ObtenerBodegas()
        {
            var response = new List<ResponseBodega>();
            var data = await _bodegaRepository.ObtenerBodegas();
            foreach (var item in data)
            {
                response.Add(new ResponseBodega
                {
                    Id = item.Id,
                    Disposicion = item.Disposicion,
                    Idfilial = item.Idfilial,
                    Nombre = item.Nombre
                });
            }
            return response;
        }
    }
}
