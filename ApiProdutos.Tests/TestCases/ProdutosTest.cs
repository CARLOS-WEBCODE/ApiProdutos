using ApiProdutos.Services.Requests;
using ApiProdutos.Tests.Helpers;
using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiProdutos.Tests.TestCases;
public class ProdutosTest
{
    [Fact]
    public async Task Post_Produtos_Return_Ok()
    {
        var faker = new Faker("pt_BR");

        #region Criando os dados da requisição

        var request = new ProdutoPostRequest
        {
            Nome = faker.Commerce.ProductName(),
            Preco = decimal.Parse(faker.Commerce.Price()),
            Quantidade = 10
        };

        var content = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8, "application/json");

        #endregion

        #region Executando o serviço de API

        var client = new HttpClient();

        var response = await client.PostAsync
            ($"{ApiHelper.Endpoint}/Produtos", content);

        #endregion

        #region Validar o resultado do teste

        response
            .StatusCode
            .Should()
            .Be(HttpStatusCode.Created);

        #endregion
    }

    [Fact(Skip = "Não implementado.")]
    public void Put_Produtos_Return_Ok()
    {

    }

    [Fact(Skip = "Não implementado.")]
    public void Put_Produtos_Return_UnprocessableEntity()
    {

    }

    [Fact(Skip = "Não implementado.")]
    public void Delete_Produtos_Return_Ok()
    {

    }

    [Fact(Skip = "Não implementado.")]
    public void Delete_Produtos_Return_UnprocessableEntity()
    {

    }

    [Fact(Skip = "Não implementado.")]
    public void GetAll_Produtos_Return_Ok()
    {

    }

    [Fact(Skip = "Não implementado.")]
    public void GetById_Produtos_Return_Ok()
    {

    }
}
