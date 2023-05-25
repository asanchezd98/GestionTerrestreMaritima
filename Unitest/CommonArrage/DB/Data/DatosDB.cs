//using GestionTerrestreMaritima.Dalc.Context;

//namespace travelExpense.viajes.XUnitTest.CommonArrange.DB.Data
//{
//    public class DatosDB
//    {
//        public GESTIONENVIOTMContext ContextoCargado { get; }

//        public DatosDB(GESTIONENVIOTMContext dbContexto)
//        {
//            ContextoCargado = dbContexto;
//        }

//        /// <summary>
//        /// Inicializa la BD in Memory 
//        /// </summary>
//        public void ParamVariables()
//        {
//            ContextoCargado.ParamVariables.Add(new ParamVariables
//            {
//                Key = new Guid("7D81360E-F2E5-454E-A51A-0099ABAD3E4B"),
//                Id = "SAPPRESENCIA",
//                FkIdParametro = "PARGENERAL",
//                Valor = "0",
//                FechaVigenciaInicio = DateTime.Parse("2018-06-22"),
//                FechaVigenciaFin = DateTime.Parse("2048-06-22"),
//                Activo = true,
//                FechaCreacion = DateTime.Parse("2018-06-22"),
//                FechaEdicion = DateTime.Parse("2018-06-22"),
//                UsuarioCreacion = "Ecopetrol",
//                UsuarioEdicion = "Ecopetrol",
//                TieneVencimiento = false,
//                TipoVariable = null,
//                Descripcion = "Presencia - Activar o Inactivar",
//                EsAuxilios = false
//            });
//            ContextoCargado.SaveChanges();

//            ContextoCargado.ParamVariables.Add(new ParamVariables
//            {
//                Key = new Guid("89E2874A-6624-4378-897B-00DC88FC89D3"),
//                Id = "PASAJETERR",
//                FkIdParametro = "TPOTGASTOS",
//                Valor = "PASAJES TERRESTRES",
//                FechaVigenciaInicio = DateTime.Parse("2018-06-27"),
//                FechaVigenciaFin = DateTime.Parse("2019-06-27"),
//                Activo = true,
//                FechaCreacion = DateTime.Parse("2018-06-27"),
//                FechaEdicion = DateTime.Parse("2018-06-27"),
//                UsuarioCreacion = "devAntonio",
//                UsuarioEdicion = "devAntonio",
//                TieneVencimiento = false,
//                TipoVariable = null,
//                Descripcion = "Otros gastos de pasajes terrestres",
//                EsAuxilios = false
//            });
//            ContextoCargado.SaveChanges();
//        }

//        public void Viajes()
//        {
//            ContextoCargado.Viajes.Add(new Viaje
//            {
//                Id = 176545L,
//                FuncionariosIdViajero = "E0017045",
//                FuncionariosNombreViajero = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                ParamCategoria = 2,
//                ParamTipoViaje = "TVNACIONAL",
//                FuncionarioIdGestor = "",
//                FuncionariosIdAprobador = "E0017045",
//                FuncionariosIdAprobadorPrevio = "",
//                ParamTipoComision = "VOPERATIVA",
//                SAPCentroCosto = "VH4000/CECO",
//                LiquidadorIdLiquidacion = 506923,
//                Descripcion = "Asistir reunión VDS Bogotá",
//                FechaInicio = DateTime.Parse("2020-01-30"),
//                FechaFin = DateTime.Parse("2020-01-31"),
//                FkEstadoViaje = "PENDAPROBO",
//                FechaCreacionViaje = DateTime.Parse("2020-01-23"),
//                FechaEdicionViaje = DateTime.Parse("2020-01-23"),
//                UsuarioCreacion = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                UsuarioEdicion = "E0602051",
//                Eliminado = false,
//                EstaCerrado = false,
//                TieneNovedades = false,
//                TieneViaticoPermanente = false,
//                ArticuloSindical = null,
//                fkIdDestinoPENA = 0L,
//                justificacionPENA = null,
//                TipoViajero = "ECP",
//                DetalleEmergencia = "TEXTO DETALLE EMERGENCIA.......",
//                FueraDePolitica = true
//            });
//            ContextoCargado.SaveChanges();
//        }

//        public void ViajesEditar()
//        {
//            ContextoCargado.Viajes.Add(new Viaje
//            {
//                Id = 176545L,
//                FuncionariosIdViajero = "E0017045",
//                FuncionariosNombreViajero = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                ParamCategoria = 2,
//                ParamTipoViaje = "TVNACIONAL",
//                FuncionarioIdGestor = null,
//                FuncionariosIdAprobador = "E0602051",
//                FuncionariosIdAprobadorPrevio = null,
//                ParamTipoComision = "VOPERATIVA",
//                SAPCentroCosto = "VH4000/CECO",
//                LiquidadorIdLiquidacion = 506923,
//                Descripcion = "Asistir reunión VDS Bogotá",
//                FechaInicio = DateTime.Parse("2020-01-30"),
//                FechaFin = DateTime.Parse("2020-01-31"),
//                FkEstadoViaje = "GUARDADO",
//                FechaCreacionViaje = DateTime.Parse("2020-01-23"),
//                FechaEdicionViaje = DateTime.Parse("2020-01-23"),
//                UsuarioCreacion = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                UsuarioEdicion = "E0602051",
//                Eliminado = false,
//                EstaCerrado = false,
//                TieneNovedades = false,
//                TieneViaticoPermanente = false,
//                ArticuloSindical = null,
//                fkIdDestinoPENA = 0L,
//                justificacionPENA = null,
//                TipoViajero = "ECP"
//            });
//            ContextoCargado.SaveChanges();
//        }

//        public void ViajesAprovadorPrevio()
//        {
//            ContextoCargado.Viajes.Add(new Viaje
//            {
//                Id = 176545L,
//                FuncionariosIdViajero = "E0017045",
//                FuncionariosNombreViajero = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                ParamCategoria = 2,
//                ParamTipoViaje = "TVNACIONAL",
//                FuncionarioIdGestor = "",
//                FuncionariosIdAprobador = "E0017045",
//                FuncionariosIdAprobadorPrevio = "E0017045",
//                ParamTipoComision = "VOPERATIVA",
//                SAPCentroCosto = "VH4000/CECO",
//                LiquidadorIdLiquidacion = 506923,
//                Descripcion = "Asistir reunión VDS Bogotá",
//                FechaInicio = DateTime.Parse("2020-01-30"),
//                FechaFin = DateTime.Parse("2020-01-31"),
//                FkEstadoViaje = "PENDAPROBO",
//                FechaCreacionViaje = DateTime.Parse("2020-01-23"),
//                FechaEdicionViaje = DateTime.Parse("2020-01-23"),
//                UsuarioCreacion = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                UsuarioEdicion = "E0602051",
//                Eliminado = false,
//                EstaCerrado = false,
//                TieneNovedades = false,
//                TieneViaticoPermanente = false,
//                ArticuloSindical = null,
//                fkIdDestinoPENA = 0L,
//                justificacionPENA = null,
//                TipoViajero = "ECP",
//                DetalleEmergencia = "TEXTO DETALLE EMERGENCIA......."
//            });
//            ContextoCargado.SaveChanges();
//        }

//        public void ViajesGestor()
//        {
//            ContextoCargado.Viajes.Add(new Viaje
//            {
//                Id = 176545L,
//                FuncionariosIdViajero = "E0017045",
//                FuncionariosNombreViajero = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                ParamCategoria = 2,
//                ParamTipoViaje = "TVNACIONAL",
//                FuncionarioIdGestor = "E0017045",
//                FuncionariosIdAprobador = "E0017045",
//                FuncionariosIdAprobadorPrevio = "E0017045",
//                ParamTipoComision = "VOPERATIVA",
//                SAPCentroCosto = "VH4000/CECO",
//                LiquidadorIdLiquidacion = 506923,
//                Descripcion = "Asistir reunión VDS Bogotá",
//                FechaInicio = DateTime.Parse("2020-01-30"),
//                FechaFin = DateTime.Parse("2020-01-31"),
//                FkEstadoViaje = "PENDAPROBO",
//                FechaCreacionViaje = DateTime.Parse("2020-01-23"),
//                FechaEdicionViaje = DateTime.Parse("2020-01-23"),
//                UsuarioCreacion = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                UsuarioEdicion = "E0602051",
//                Eliminado = false,
//                EstaCerrado = false,
//                TieneNovedades = false,
//                TieneViaticoPermanente = false,
//                ArticuloSindical = null,
//                fkIdDestinoPENA = 0L,
//                justificacionPENA = null,
//                TipoViajero = "ECP",
//                DetalleEmergencia = "TEXTO DETALLE EMERGENCIA......."
//            });
//            ContextoCargado.SaveChanges();
//        }

//        public void ViajesNotificacion()
//        {
//            ContextoCargado.Viajes.Add(new Viaje
//            {
//                Id = 401045,
//                FuncionariosIdViajero = "E9000061",
//                FuncionariosNombreViajero = "JOSE MIGUEL GALINDO SANCHEZ",
//                ParamCategoria = 2,
//                ParamTipoViaje = "TVEMERGENCIA",
//                FuncionarioIdGestor = "",
//                FuncionariosIdAprobador = "E0017045",
//                FuncionariosIdAprobadorPrevio = "",
//                ParamTipoComision = "VOPERATIVA",
//                SAPCentroCosto = "VH4000/CECO",
//                LiquidadorIdLiquidacion = 506923,
//                Descripcion = "Asistir reunión VDS Bogotá",
//                FechaInicio = DateTime.Parse("2021-07-31"),
//                FechaFin = DateTime.Parse("2021-08-14"),
//                FkEstadoViaje = "GUARDADO",
//                FechaCreacionViaje = DateTime.Parse("2021-07-15"),
//                FechaEdicionViaje = DateTime.Parse("2021-07-15"),
//                UsuarioCreacion = "PEDRO JAVIER VILLALOBOS GONZALEZ",
//                UsuarioEdicion = "E0602051",
//                Eliminado = false,
//                EstaCerrado = false,
//                TieneNovedades = false,
//                TieneViaticoPermanente = false,
//                ArticuloSindical = null,
//                fkIdDestinoPENA = 0L,
//                justificacionPENA = null,
//                TipoViajero = "ECP",
//                DetalleEmergencia = "TEXTO DETALLE EMERGENCIA......."
//            });
//            ContextoCargado.SaveChanges();
//        }
//    }
//}
