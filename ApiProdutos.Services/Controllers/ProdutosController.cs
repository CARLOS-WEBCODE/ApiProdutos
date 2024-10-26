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
}
