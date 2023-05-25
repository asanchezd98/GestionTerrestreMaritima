using GestionTerrestreMaritima.BO.Interfaces;
using GestionTerrestreMaritima.Dalc.Base;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Entity;
using GestionTerrestreMaritima.Model.Reponse;

namespace GestionTerrestreMaritima.BO.RepositoryBO
{
    public class ParametroRepositoryBo : IParametroRepositoryBo
    {
        private readonly ParametroRepository _parametroRepository;
        public ParametroRepositoryBo(GESTIONENVIOTMContext context)
        {
            _parametroRepository = new ParametroRepository(context);
        }

        public async Task<List<ResponseParametro>> ObtenerParametrosxNombre(string nombre)
        {
            var response = new List<ResponseParametro>();
            var data = await _parametroRepository.ObtenerParametrosxNombre(nombre);
            foreach (var item in data)
            {
                response.Add(new ResponseParametro
                {
                    Nombreparametro = item.Nombreparametro,
                    Valorparametro = item.Valorparametro,
                    Idfilial = item.Idfilial
                });
            }
            return response;
        }

        public async Task<List<ResponseParametro>> ObtenerParametrosxfiltro(string parametro, string idFilial)
        {
            var response = new List<ResponseParametro>();
            var data = await _parametroRepository.ObtenerParametrosxfiltro(parametro, idFilial);
            foreach (var item in data)
            {
                response.Add(new ResponseParametro
                {
                    Nombreparametro = item.Nombreparametro,
                    Valorparametro = item.Valorparametro,
                    Idfilial = item.Idfilial
                });
            }
            return response;
        }
    }
}
