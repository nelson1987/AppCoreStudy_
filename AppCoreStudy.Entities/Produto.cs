using System;
using System.Collections.Generic;

namespace AppCoreStudy.Entities
{
    //public class Produto
    //{
    //    public virtual int IdProduto { get; set; }
    //    public virtual string Nome { get; set; }
    //    public virtual decimal Preco { get; set; }
    //    public virtual int Quantidade { get; set; }
    //}

    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EmpresaTipoEnum Tipo { get; set; }
        public string Documento { get; set; }
        public List<Produto> Produzidos { get; set; }

        public bool isValid()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new AppCoreStudyDomainValidationException("O nome não pode ser nulo ou estar vazio.");
            if (string.IsNullOrEmpty(Documento))
                throw new AppCoreStudyDomainValidationException("O documento não pode ser nulo ou estar vazio.");
            return true;
        }
    }

    public enum EmpresaTipoEnum
    {
        PessoaFisica = 1,
        PessoaJuridica = 2,
        Estrangeiro = 3
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public MaterialServico Material { get; set; }
        public bool Ativo { get; set; }

        public bool isValid()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new AppCoreStudyDomainValidationException("O nome não pode ser nulo ou estar vazio.");
            return true;
        }
    }

    public class MaterialServico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public MaterialServicoEnum Tipo { get; set; }
    }

    public enum MaterialServicoEnum
    {
        Material = 1,
        Servico = 2
    }

    public class Inservivel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

        public bool isValid()
        {
            throw new NotImplementedException();
        }
    }
}
