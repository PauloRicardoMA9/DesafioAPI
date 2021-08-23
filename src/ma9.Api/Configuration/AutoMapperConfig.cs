using AutoMapper;
using ma9.Business.Models.ViewModels;
using ma9.Business.Models;

namespace ma9.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Contato, ContatoViewModel>().ReverseMap();
        }
    }
}
