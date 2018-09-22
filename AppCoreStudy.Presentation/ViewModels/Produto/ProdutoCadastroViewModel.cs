using System.ComponentModel.DataAnnotations;

namespace AppCoreStudy.Presentation.ViewModels.Produto
{
    public class ProdutoCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o preco.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        public int Quantidade { get; set; }
    }
}
