var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para la aplicaci�n
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n para el entorno de producci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configura la ruta para los archivos est�ticos en React (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    // Servir archivos est�ticos de la app React
    app.UseStaticFiles();
}

// Otros middleware
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Mapea los controladores para el backend de .NET
app.MapControllers();

// Configuraci�n para servir el frontend de React en desarrollo
app.MapFallbackToFile("index.html");  // Sirve el index.html de React

app.Run();
