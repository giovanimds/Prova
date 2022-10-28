using System.Text.Json.Serialization;
using WebAppProva.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddSqlite<DataContext>("Data Source=database.db");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    "FolhaCadastrar",
    "{controller=FolhaController}/{action=Cadastrar}/{*folha}");
app.MapControllerRoute(
    "FolhaBuscar",
    "{controller=FolhaController}/{action=Buscar}/{cpf}/{mes}/{ano}");
app.MapControllerRoute(
    "FolhaFiltrar",
    "{controller=FolhaController}/{action=Filtrar}/{ano?}/{mes?}");
app.MapControllerRoute(
    "FolhaListar",
    "{controller=FolhaController}/{action=Listar}");
app.MapControllerRoute(
    "FuncionarioCadastrar",
    "{controller=FuncionarioController}/{action=Cadastrar}/{*funcionario}");
app.Run();