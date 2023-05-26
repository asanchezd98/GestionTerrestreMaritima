using GestionTerrestreMaritima.Dalc.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace XUnitTest.CommonArrange.DB
{
    /// <summary>
    /// Genera un mock dinamico de BD
    /// </summary>
    public class DatabaseDinamic
    {
        /// <summary>
        /// Inicializa la BD con un nombre de metodo test, a find e asegurar un contexto unico por método
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public GESTIONENVIOTMContext InicializaBdTestUnico(string test = "Mock")
        {
            string databaseName = $"GESTIONENVIOTM_{test}" + DateTime.Now.Ticks.ToString();
            GESTIONENVIOTMContext DbContextTest;
            /* Create a Memory Database instead of using the SQL */
            var options = new DbContextOptionsBuilder<GESTIONENVIOTMContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            DbContextTest = new GESTIONENVIOTMContext(options);
            return DbContextTest;
        }
    }
}
