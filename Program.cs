using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;
using RGNRK.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication()
        .AddGoogle(options =>
        {
            options.ClientId = builder.Configuration["GoogleConnection:ClientId"];
            options.ClientSecret = builder.Configuration["GoogleConnection:ClientSecret"];
        })
        .AddMicrosoftAccount(options =>
        {
            options.ClientId = builder.Configuration["MicrosoftConnection:ClientId"];
            options.ClientSecret = builder.Configuration["MicrosoftConnection:ClientSecret"];
        })
        .AddTwitter(options =>
        {
            options.ConsumerKey = builder.Configuration["TwitterConnection:APIKey"];
            options.ConsumerSecret = builder.Configuration["TwitterConnection:APIKeySecret"];
            options.CallbackPath = new PathString("/signin-twitter");
        });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var serverVersion = ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("RGNRKContextConnection"));
builder.Services.AddDbContext<RGNRKContext>(options =>
options.UseMySql(
    builder.Configuration.GetConnectionString("RGNRKContextConnection"), serverVersion, mySqlOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RGNRKContext>();

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

using (var scope = app.Services.CreateScope())
{
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
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string email = "admin@admin.com";
    string password = "Admin@123";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();