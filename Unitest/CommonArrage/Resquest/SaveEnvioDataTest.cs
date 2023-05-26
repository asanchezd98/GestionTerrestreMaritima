using GestionTerrestreMaritima.Model.Request;
using System;
using System.Collections;
using System.Collections.Generic;

namespace XUnitTest.CommonArrange.Resquest
{
    public class SaveEnvioDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new RequestEnvio {
                                        Cantproducto = 10,
                                        Fechaentrega = DateTime.Now,
                                        Filial = "MRTM",
                                        Idbodega =1,
                                        Idcliente = 1,
                                        Idtipoproducto = 1,
                                        Precioenvio = 10000
                                        },
                                        true
                                   };

            yield return new object[] { new RequestEnvio {
                                        Cantproducto = 10,
                                        Fechaentrega = DateTime.Now,
                                        Idbodega =1,
                                        Idcliente = 1,
                                        Idtipoproducto = 1,
                                        },
                                        false
                                   };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
