﻿using Microsoft.OpenApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace ApiProdutos.Services.Configurations;

public static class SwaggerConfiguration
{
    public static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "API para controle de produtos",
                Description = "Projeto desenvolvido em NET6 API com EntityFramework SqlServer",
                Contact = new OpenApiContact
                {
                    Name = "COTI Informática",
                    Url = new Uri("http://www.cotiinformatica.com.br"),
                    Email = "contato@cotiinformatica.com.br"
                }
            });
        });
    }
}
