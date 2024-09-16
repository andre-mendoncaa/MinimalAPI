using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arange
        var adm = new Administrador();

        //Act
        adm.Email = "teste@gmail.com";
        adm.Senha = "teste";
        adm.Perfil = "Editor";
        adm.Id = 1;

        //Assert
        Assert.AreEqual(1 , adm.Id);
        Assert.AreEqual("teste@gmail.com" , adm.Email);
        Assert.AreEqual("teste" , adm.Senha);
        Assert.AreEqual("Editor" , adm.Perfil);
    }
}