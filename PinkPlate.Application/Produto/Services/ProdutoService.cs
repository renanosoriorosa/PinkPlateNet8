using AutoMapper;
using PinkPlate.Application.Base;
using PinkPlate.Application.Notificacoes.Interfaces;
using PinkPlate.Application.Produtos.Dtos;
using PinkPlate.Application.Produtos.Interfaces;
using PinkPlate.Domain.Produto.Models;
using PinkPlate.Domain.Produto.Models.Validations;
using PinkPlate.Infrastructure.Repository.Produtos.Interfaces;

namespace PinkPlate.Application.Produtos.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(INotificador notificador, IProdutoRepository produtoRepository, IMapper mapper) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<bool> Adicionar(ProdutoDto produto)
        {
            var produtoNovo = _mapper.Map<Produto>(produto);

            if (!ExecutarValidacao(new ProdutoValidation(), produtoNovo)) return false;

            await _produtoRepository.Adicionar(produtoNovo);
            return true;
        }

        public Task Atualizar(ProdutoDto premio)
        {
            throw new NotImplementedException();
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
