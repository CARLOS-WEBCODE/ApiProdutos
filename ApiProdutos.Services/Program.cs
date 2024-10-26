using ApiProdutos.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region

AutoMapperConfiguration.AddAutoMapper(builder);
CorsConfiguration.AddCors(builder);
EntityFrameworkConfiguration.AddEntityFramework(builder);
SwaggerConfiguration.AddSwagger(builder);

#endregion

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

CorsConfiguration.UseCors(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
