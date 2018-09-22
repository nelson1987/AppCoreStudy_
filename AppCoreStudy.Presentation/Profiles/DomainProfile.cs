using AppCoreStudy.Entities;
using AppCoreStudy.Presentation.ViewModels.Produto;
using AutoMapper;

namespace AppCoreStudy.Presentation.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            #region Entity To ViewModel

            CreateMap<Produto, ProdutoConsultaViewModel>();
                //.ForMember(dest => dest.Total,
                //src => src.MapFrom(p => p.Preco * p.Quantidade));

            #endregion

            #region ViewModel To Entity

            CreateMap<ProdutoCadastroViewModel, Produto>();
            CreateMap<ProdutoConsultaViewModel, Produto>();

            #endregion
        }
    }
}
