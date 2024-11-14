using PinkPlate.Domain.Produto.Models;
using PinkPlate.Infrastructure.Context;
using PinkPlate.Infrastructure.Repository.Produtos.Interfaces;

namespace PinkPlate.Infrastructure.Repository.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly RNContext _context;

        public ProdutoRepository(RNContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
