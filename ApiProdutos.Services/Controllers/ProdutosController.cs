using ApiProdutos.Infra.Data.Entities;
using ApiProdutos.Infra.Data.Interfaces;
using ApiProdutos.Services.Requests;
using ApiProdutos.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper)
    {
        _produtoRepository = produtoRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Post(ProdutoPostRequest request)
    {
        try
        {
            var produto = _mapper.Map<Produto>(request);

            _produtoRepository.Add(produto);

            var response = _mapper.Map<ProdutoGetResponse>(produto);
            return StatusCode(201, response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPut]
    public IActionResult Put(ProdutoPutRequest request)
    {
        try
        {
            var produto = _produtoRepository.Get(request.IdProduto);

            if (produto == null)
                return StatusCode(422, new { message = "ID inválido. Produto não encontrado." });

            _mapper.Map(request, produto);

            _produtoRepository.Update(produto);

            var response = _mapper.Map<ProdutoGetResponse>(produto);
            return StatusCode(200, response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message});
        }
    }
}
