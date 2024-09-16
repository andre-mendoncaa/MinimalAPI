using System.Data.Common;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.DB;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorServicoTeste
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
            
            // Configurar o ConfigurationBuilder
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE admistradores");

            var adm = new Administrador
            {
                Email = "teste@gmail.com",
                Senha = "teste",
                Perfil = "Editor",
            };
            
            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);

            // Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
            Assert.AreEqual("teste@gmail.com", adm.Email);
            Assert.AreEqual("teste", adm.Senha);
            Assert.AreEqual("Editor", adm.Perfil);
        }

        [TestMethod]
        public void TestandoBuscarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE admistradores");

            var adm = new Administrador
            {
                Email = "teste@gmail.com",
                Senha = "teste",
                Perfil = "Editor",
            };
            
            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);
            var admBusca = administradorServico.BuscaPorId(adm.Id);

            // Assert
            Assert.AreEqual(1, admBusca.Id);
        }
    }
}
