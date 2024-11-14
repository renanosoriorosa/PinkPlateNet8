using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PinkPlate.API.Interfaces;
using PinkPlate.Application.Notificacoes.Interfaces;
using PinkPlate.Application.Produtos.Dtos;
using PinkPlate.Application.Produtos.Interfaces;

namespace PinkPlate.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(INotificador notificador, IUser appUser, IProdutoService produtoService) : base(notificador, appUser)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProdutoDto produto)
        {
            await _produtoService.Adicionar(produto);

            return CustomResponse();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetLista()
        {
            return CustomResponse();
        }
    }
}
