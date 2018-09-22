using AppCoreStudy.Entities;
using AppCoreStudy.Repository;
using System.Collections.Generic;

namespace AppCoreStudy.Services
{
    //public class EmpresaService
    //{

    //    public void Cadastrar(Empresa empresa)
    //    {
    //        if (empresa.isValid())
    //            _repository.Insert(empresa);
    //    }

    //    public void Alterar(Empresa empresa)
    //    {
    //        if (empresa.isValid())
    //            _repository.Update(empresa);
    //    }

    //    public List<Empresa> Listar()
    //    {
    //        return _repository.GetAll();
    //    }

    //    public void CadastrarFilial(int idEmpresa, Empresa filial)
    //    {
    //        if (filial.isValid())
    //        {
    //            Empresa matriz = _repository.GetById(idEmpresa);
    //            matriz.Filial.Add(filial);
    //            Alterar(matriz);
    //        }
    //    }

    //    public void Anexar(int idEmpresa, Produto produto)
    //    {
    //        if (produto.isValid())
    //        {
    //            Empresa matriz = _repository.GetById(idEmpresa);
    //            matriz.Produzidos.Add(produto);
    //            Alterar(matriz);
    //        }
    //    }
    //}

    public interface IProdutoService
    {
        void Cadastrar(Produto produto);
        void Editar(Produto produto);
        void Inativar(int idProduto);
        void Anexar(int idProduto, MaterialServico material);
    }
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository repository;
        public ProdutoService(ProdutoRepository repository)
        {
            this.repository = repository;
        }
        public void Cadastrar(Produto produto)
        {
            if (produto.isValid())
                repository.Insert(produto);
        }
        public void Editar(Produto produto)
        {
            if (produto.isValid())
                repository.Update(produto);
        }
        public void Inativar(int idProduto)
        {
            Produto produto = repository.GetById(idProduto);
            produto.Ativo = false;
            if (produto.isValid())
                Editar(produto);
        }
        public void Anexar(int idProduto, MaterialServico material)
        {
            Produto produto = repository.GetById(idProduto);
            produto.Material = material;
            if (produto.isValid())
                Editar(produto);
        }
    }

    //public class InservivelService
    //{
    //    public void Cadastrar(Inservivel inservivel)
    //    {
    //        if (inservivel.isValid())
    //            _repository.Insert(inservivel);
    //    }
    //}
}
