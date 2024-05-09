using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RGNRK.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication()
        .AddGoogle(options =>
        {
            options.ClientId = builder.Configuration["GoogleConnection:ClientId"];
            options.ClientSecret = builder.Configuration["GoogleConnection:ClientSecret"];
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

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<RGNRKContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapRazorPages();

app.Run();



    

