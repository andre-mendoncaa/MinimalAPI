using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arange
        var veiculo = new Veiculo();

        //Act
        veiculo.Nome = "407";
        veiculo.Marca = "Peugeot";
        veiculo.Ano = 2005;
        veiculo.Id = 1;

        //Assert
        Assert.AreEqual("407", veiculo.Nome);
        Assert.AreEqual("Peugeot", veiculo.Marca);
        Assert.AreEqual(2005, veiculo.Ano);
        Assert.AreEqual(1, veiculo.Id);
    }
}