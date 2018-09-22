using AppCoreStudy.Entities;
using NUnit.Framework;

namespace AppCoreStudy.Services.Tests
{
    [TestFixture] //classe de teste
    public class ProdutoRepositoryTest
    {
        //método que será executado antes do teste iniciar
        [SetUp]
        public void SetUp()
        {
            //InitializeParameters();
        }

        [Test] //método de teste
        public void CrudProduto()
        {
            //Guid id = CreateTest();
            Empresa snk = new Empresa();
            snk.Nome = "SNK";
            snk.Tipo = EmpresaTipoEnum.PessoaJuridica;
            snk.Documento = "123.456.789/0001-10";

            Produto parafusoSextavado = new Produto();
            parafusoSextavado.Nome = "ParafusoSextavado";
            parafusoSextavado.Material = new MaterialServico
                {
                    Nome = "Borracha",
                    Tipo = MaterialServicoEnum.Material
                };
            snk.Produzidos.Add(parafusoSextavado);

        }
    }
}