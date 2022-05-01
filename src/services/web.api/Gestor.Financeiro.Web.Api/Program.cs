using Gestor.Financeiro.Web.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("FullAccess");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
