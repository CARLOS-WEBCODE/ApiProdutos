namespace ApiProdutos.Services.Configurations;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapper(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
