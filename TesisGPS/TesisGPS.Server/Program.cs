var builder = WebApplication.CreateBuilder(args);

// Servicios de controlador
builder.Services.AddControllersWithViews();

// Configuraci�n para servir archivos est�ticos
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";  // Carpeta de salida de la compilaci�n de React
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Usar HTTPS y archivos est�ticos
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Configurar el SPA
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");  // Configura el puerto de desarrollo de React
    }
});

app.Run();
