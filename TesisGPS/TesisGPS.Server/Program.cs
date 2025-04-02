var builder = WebApplication.CreateBuilder(args);

// Servicios de controlador
builder.Services.AddControllersWithViews();

// Configuración para servir archivos estáticos
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/build";  // Carpeta de salida de la compilación de React
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Usar HTTPS y archivos estáticos
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
