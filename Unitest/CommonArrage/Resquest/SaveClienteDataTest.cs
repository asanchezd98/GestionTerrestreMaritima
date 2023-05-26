using GestionTerrestreMaritima.Model.Reponse;
using GestionTerrestreMaritima.Model.Request;
using System;
using System.Collections;
using System.Collections.Generic;

namespace XUnitTest.CommonArrange.Resquest
{
    public class SaveClienteDataTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new RequestCliente {
                                        documento = "1001231",
                                        nombre = "abner",
                                        telefono = "00000",
                                        usuario = "userabner",
                                        password = "12345"
                                        },
                                        true
                                   };

            yield return new object[] { new RequestCliente {
                                        documento = "1001231",
                                        nombre = "abner",
                                        telefono = "00000",
                                        usuario = "userabner"
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
