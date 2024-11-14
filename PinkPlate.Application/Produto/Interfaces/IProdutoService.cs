using PinkPlate.Application.Produtos.Dtos;

namespace PinkPlate.Application.Produtos.Interfaces
{
    public interface IProdutoService
    {
        Task<bool> Adicionar(ProdutoDto produto);
        Task Atualizar(ProdutoDto produto);
        Task Remover(int id);
    }
}
