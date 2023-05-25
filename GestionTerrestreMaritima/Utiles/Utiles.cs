using GestionTerrestreMaritima.Dalc.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GestionTerrestreMaritima.Utiles
{
    public class Utiles
    {
        private readonly GESTIONENVIOTMContext _context;
        public Utiles(GESTIONENVIOTMContext context)
        {
            _context = context;
        }
        public string generarNiVehiculo(string tipoGestion)
        {
            return GenerarNi(3, tipoGestion == "MRTM" ? 4 : 3);
        }

        public string GenerarCadenaAlfanumerica()
        {
            int longitud = 10;
            Random random = new Random();
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            char[] cadena = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                cadena[i] = caracteresPermitidos[indice];
            }

            return new string(cadena);
        }

        static string GenerarNi(int cantLetras, int cantNumeros)
        {
            Random random = new Random();

            string letras = GenerarLetrasAleatorias(random, cantLetras);
            string numeros = GenerarNumerosAleatorios(random, cantNumeros);
            string auxLetra = "";

            if (cantNumeros == 4)
            {
                auxLetra = GenerarLetrasAleatorias(random, 1);
            }

            string cadena = letras + numeros + auxLetra;
            return cadena;
        }

        static string GenerarLetrasAleatorias(Random random, int longitud)
        {
            string letrasPermitidas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] letras = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                letras[i] = letrasPermitidas[random.Next(letrasPermitidas.Length)];
            }

            return new string(letras);
        }

        static string GenerarNumerosAleatorios(Random random, int longitud)
        {
            string numerosPermitidos = "0123456789";
            char[] numeros = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                numeros[i] = numerosPermitidos[random.Next(numerosPermitidos.Length)];
            }

            return new string(numeros);
        }

        public bool ValidarToken(string token)
        {
            var tokenDB = _context.Parametros.Where(x => x.Nombreparametro == "TOKEN").FirstAsync().Result.Valorparametro;
            return ("Bearer " + tokenDB) == token;
        }

        public string EncryptSHA256(string str)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sHA256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
