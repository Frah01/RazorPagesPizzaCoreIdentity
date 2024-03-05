using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesPizza.Data;
//using RazorPagesPizza.Data;
// using RazorPagesPizza.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("RazorPagesPizzaAuthConnection") ?? throw new InvalidOperationException("Connection string 'RazorPagesPizzaAuthConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("RazorPagesPizzaAuthConnection");

builder.Services.AddDbContext<RazorPagesPizzaAuth>(options => options.UseSqlServer(connectionString));

// builder.Services.AddDefaultIdentity<RazorPagesPizzaAuth>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RazorPagesPizzaAuth>();

// builder.Services.AddDefaultIdentity<>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RazorPagesPizzaAuth>();
//builder.Services.AddDbContext<RazorPagesPizzaAuth>(options => options.UseSqlServer(connectionString));

// NO Unable to resolve service for type 'Microsoft.AspNetCore.Identity.SignInManager
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//      .AddEntityFrameworkStores<RazorPagesPizzaAuth>();
//builder.Services.AddDbContext<RazorPagesPizzaAuth>(options => options.UseSqlServer(connectionString));

// builder.Services.AddDefaultIdentity<>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RazorPagesPizzaAuth>();

// https://stackoverflow.com/questions/52089864/unable-to-resolve-service-for-type-iemailsender-while-attempting-to-activate-reg

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<RazorPagesPizzaAuth>();
    //.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
