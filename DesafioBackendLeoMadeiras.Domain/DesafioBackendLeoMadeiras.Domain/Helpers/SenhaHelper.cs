using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DesafioBackendLeoMadeiras.Domain.Helpers
{
    public class SenhaHelper
    {
        public string GerarSenha()
        {
            const string caracteresValidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#_-";

            StringBuilder senha;
            var random = new Random();

            do
            {
                var passwordLength = new Random().Next(15, 25);
                senha = new StringBuilder();

                while (0 < passwordLength--)
                {
                    senha.Append(caracteresValidos[random.Next(caracteresValidos.Length)]);
                }

            } while (!ValidarSenha(senha.ToString()));

            return senha.ToString();
        }

        public static bool VerificarSenha(string senhaCommand, string senhaUsuario)
        {
            return senhaUsuario.Equals(senhaCommand);
        }

        public static bool ValidarSenha(string senha)
        {
            var temNoMinimo15caracteres = new Regex(@".{15,}");
            var temCaractereCaixaAlta = new Regex(@"[A-Z]+");
            var temCaractereCaixaBaixa = new Regex(@"[a-z]+");
            var temSimbolos = new Regex(@"[!@#_-]");
            var temCaractereRepetido = ContemCaractereRepetido(senha);

            return temNoMinimo15caracteres.IsMatch(senha) &&
                temCaractereCaixaAlta.IsMatch(senha) &&
                temCaractereCaixaBaixa.IsMatch(senha) &&
                temSimbolos.IsMatch(senha) &&
                !temCaractereRepetido;
        }

        private static bool ContemCaractereRepetido(string senha)
        {
            var caracteres = senha.ToCharArray();
            for (int i = 0; i < caracteres.Length - 1; i++)
                if (caracteres[i] == caracteres[i + 1])
                    return true;

            return false;
        }
    }
}
