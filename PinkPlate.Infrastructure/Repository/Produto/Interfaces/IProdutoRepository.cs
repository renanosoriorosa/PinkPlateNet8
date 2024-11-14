using PinkPlate.Domain.Produto.Models;

namespace PinkPlate.Infrastructure.Repository.Produtos.Interfaces
{
    public interface IProdutoRepository
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Produto produto);
    }
}
