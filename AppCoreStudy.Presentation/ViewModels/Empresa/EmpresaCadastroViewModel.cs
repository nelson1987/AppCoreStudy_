namespace AppCoreStudy.Presentation.ViewModels.Empresa
{
    public class EmpresaCadastroViewModel
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Tipo { get; set; }
    }

    public class EmpresaEdicaoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Tipo { get; set; }
    }

    public class EmpresaConsultaViewModel
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Tipo { get; set; }
    }
}
