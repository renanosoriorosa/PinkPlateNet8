using AutoMapper;
using PinkPlate.Application.Produtos.Dtos;
using PinkPlate.Domain.Produto.Models;

namespace PinkPlate.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
