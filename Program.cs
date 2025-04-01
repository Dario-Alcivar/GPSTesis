var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para la aplicación
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración para el entorno de producción
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configura la ruta para los archivos estáticos en React (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    // Servir archivos estáticos de la app React
    app.UseStaticFiles();
}

// Otros middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Mapea los controladores para el backend de .NET
app.MapControllers();

// Configuración para servir el frontend de React en desarrollo
app.MapFallbackToFile("index.html");  // Sirve el index.html de React

app.Run();
