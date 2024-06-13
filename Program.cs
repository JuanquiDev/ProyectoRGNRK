using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(8080); // HTTP port
//    serverOptions.ListenAnyIP(8081, listenOptions =>
//    {
//        listenOptions.UseHttps(); // HTTPS port
//    });
//});

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("PersonalCalendar", "/");
    });

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["GoogleConnection:ClientId"];
        options.ClientSecret = builder.Configuration["GoogleConnection:ClientSecret"];
    });

builder.Services.AddAuthentication()
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration["MicrosoftConnection:ClientId"];
        options.ClientSecret = builder.Configuration["MicrosoftConnection:ClientSecret"];
    });

builder.Services.AddAuthentication()
    .AddTwitter(options =>
    {
        options.ConsumerKey = builder.Configuration["TwitterConnection:APIKey"];
        options.ConsumerSecret = builder.Configuration["TwitterConnection:APIKeySecret"];
        options.CallbackPath = new PathString("/signin-twitter");
    });

builder.Services.AddControllers();

// Get the connection string from environment variable or configuration file
string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                          builder.Configuration.GetConnectionString("RGNRKContextConnection")!;

var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<RGNRKContext>(options =>
    options.UseMySql(
        connectionString,
        serverVersion,
        mySqlOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RGNRKContext>();

// Configuración de EmailSettings
var emailSettings = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
builder.Services.AddSingleton(emailSettings!);
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<RGNRKContext>();

    try
    {
        // Aplica migraciones solo si no han sido aplicadas ya
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Manejo de excepción: podrías registrar el error o manejarlo de otra manera
        // Nota: Reemplaza esto con la lógica adecuada de manejo de errores en tu aplicación
        Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
    }

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new List<string> { "Admin", "Manager", "Coach", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string email = "admin@admin.com";
    string password = "Admin@123";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User
        {
            UserName = email,
            Email = email
        };

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
