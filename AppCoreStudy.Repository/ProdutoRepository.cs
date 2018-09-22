using AppCoreStudy.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AppCoreStudy.Repository
{
    public class ProdutoRepository
    {
        #region Atributos

        private IConfiguration configuration;
        private readonly string connectionString;

        #endregion

        #region Construtor

        public ProdutoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = "AulaAspNetCore";
        }

        #endregion

        //Inserir Produto na base de dados
        public void Insert(Produto produto)
        {
            var query = "INSERT INTO Produto(Nome, Preco, Quantidade) "
                        + "VALUES(@Nome, @Preco, @Quantidade);";

            using (var conn = new SqlConnection(configuration.GetConnectionString(connectionString)))
            {
                conn.Execute(query, produto);
            }
        }

        //Inserir Produto na base de dados
        public void Update(Produto produto)
        {
            var query = "Update Produto" +
                "   SET Nome = @Nome," +
                "   Preco = @Preco," +
                "   Quantidade = @Quantidade " +
                "   WHERE IDPRODUTO = " +
                produto.Id;

            using (var conn = new SqlConnection(configuration.GetConnectionString(connectionString)))
            {
                conn.Execute(query, produto);
            }
        }

        //Inserir Produto na base de dados
        public void Delete(int id)
        {
            var query = "Delete from Produto" +
                "   WHERE IDPRODUTO = " + id;

            using (var conn = new SqlConnection(configuration.GetConnectionString(connectionString)))
            {
                conn.Execute(query, new { IdProduto = id });
            }
        }

        public List<Produto> FindAll()
        {
            string query = "SELECT * from Produto";

            using (var conn = new SqlConnection(configuration.GetConnectionString(connectionString)))
            {
                return conn.Query<Produto>(query).ToList();
            }
        }

        public Produto GetById(int id)
        {
            string query = "SELECT * from Produto WHERE IdProduto = @IdProduto";

            using (var conn = new SqlConnection(configuration.GetConnectionString(connectionString)))
            {
                return conn.Query<Produto>(query, new { IdProduto = id  }).FirstOrDefault();
            }
        }
    }
}
