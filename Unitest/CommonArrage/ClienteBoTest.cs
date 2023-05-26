using GestionTerrestreMaritima.BO.RepositoryBO;
using GestionTerrestreMaritima.Dalc.Context;
using GestionTerrestreMaritima.Model.Request;
using System;
using XUnitTest.CommonArrange.DB;
using XUnitTest.CommonArrange.DB.Data;
using XUnitTest.CommonArrange.Resquest;

namespace XUnitTest.RepositoryBO
{
    public class ClienteBoTest
    {
        public ClienteBoTest()
        {
        }

        [Theory]
        [ClassData(typeof(SaveClienteDataTest))]
        public void CrearCliente(RequestCliente filtro, bool expected)
        {
            //Arranges
            GESTIONENVIOTMContext DbContextTest = new DatabaseDinamic().InicializaBdTestUnico();
            var cargueMockBd = new DatosDB(DbContextTest);
            cargueMockBd.Clientes();
            cargueMockBd.Parametro();
            DbContextTest = cargueMockBd.ContextoCargado;

            //ACT
            //if (expected == false)
            //    DbContextTest.Dispose();

            var repository = new ClienteRepositoryBo(DbContextTest);
            var resultadoAct = repository.AddCLiente(filtro);

            //Assert
            Assert.Equal(expected, resultadoAct);
        }


        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ObtenerClientes(bool expected)
        {
            //Arranges
            GESTIONENVIOTMContext DbContextTest = new DatabaseDinamic().InicializaBdTestUnico();
            var cargueMockBd = new DatosDB(DbContextTest);
            cargueMockBd.Clientes();
            DbContextTest = cargueMockBd.ContextoCargado;

            //ACT
            if (expected == false)
                DbContextTest.Dispose();

            var repository = new ClienteRepositoryBo(DbContextTest);
            var clientes = repository.ObtenerClientes().Result;
            bool resultadoAct;

            if (clientes.Count == 0)
            {
                resultadoAct = false;
            }
            else
            {
                resultadoAct = true;
            }

            //Assert
            Assert.Equal(expected, resultadoAct);
        }
    }
}
