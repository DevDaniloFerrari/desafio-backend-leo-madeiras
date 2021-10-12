using DesafioBackendLeoMadeiras.Domain.Helpers;
using Xunit;

namespace DesafioBackendLeoMadeiras.Tests.Helpers
{
    public class SenhaHelperTest
    {
        [Fact]
        public void GerarSenha_DeveRetornarSenha()
        {
            var senha = SenhaHelper.GerarSenha();

            Assert.True(SenhaHelper.ValidarSenha(senha));
        }

        [Fact]
        public void ValidarSenha_QuandoSenhaTiverMenosDe15Caracteres_DeveRetornarFalso()
        {
            var senha = "HEJDKCcsjeU@Ua";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.False(result);
        }

        [Fact]
        public void ValidarSenha_QuandoSenhaNaoTiverCaractereMaiusculo_DeveRetornarFalso()
        {
            var senha = "hejdkctsjeu@uab82";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.False(result);
        }

        [Fact]
        public void ValidarSenha_QuandoSenhaNaoTiverCaractereMinusculo_DeveRetornarFalso()
        {
            var senha = "HEJDCXJED@UAB82";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.False(result);
        }


        [Fact]
        public void ValidarSenha_QuandoSenhaNaoTiverSimbolos_DeveRetornarFalso()
        {
            var senha = "HEJDKCcxsjeUFUab82";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.False(result);
        }

        [Fact]
        public void ValidarSenha_QuandoSenhaTiverCaracteresRepetidos_DeveRetornarFalso()
        {
            var senha = "HEJDKCccxsjeU@Uab82";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.False(result);
        }

        [Fact]
        public void ValidarSenha_QuandoSenhaForValida_DeveRetornarTrue()
        {
            var senha = "HEJDKCcxsjeU@Uab82";

            var result = SenhaHelper.ValidarSenha(senha);

            Assert.True(result);
        }

        [Fact]
        public void VerificarSenha_QuandoSenhasForemIguais_DeveRetornarVerdadeiro()
        {
            var passwordCommand = "HEJDKCcxsjeU@Uab82";
            var passwordUser = "HEJDKCcxsjeU@Uab82";

            var result = SenhaHelper.VerificarSenha(passwordCommand, passwordUser);

            Assert.True(result);
        }


        [Fact]
        public void VerificarSenha_QuandoSenhaForemDiferentes_DeveRetornarFalso()
        {
            var passwordCommand = "HEJDKCcxsjeU@Uab82";
            var passwordUser = "HEJDKCcxsjeU@Uab23";

            var result = SenhaHelper.VerificarSenha(passwordCommand, passwordUser);

            Assert.False(result);
        }
    }
}
