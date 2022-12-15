using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Proiect_Web_Onetiu_Malan.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Destinations");
    options.Conventions.AllowAnonymousToPage("/Destinations/Index");
    options.Conventions.AllowAnonymousToPage("/Destinations/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
});
builder.Services.AddDbContext<Proiect_Web_Onetiu_MalanContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Web_Onetiu_MalanContext") ?? throw new InvalidOperationException("Connection string 'Proiect_Web_Onetiu_MalanContext' not found.")));
builder.Services.AddDbContext<AgencyIdentityContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("Proiect_Web_Onetiu_MalanContext") ?? throw new InvalidOperationException("Connectionstring 'Proiect_Web_Onetiu_MalanContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AgencyIdentityContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
