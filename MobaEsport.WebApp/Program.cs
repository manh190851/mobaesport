using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.EntityModel;
using Microsoft.AspNetCore.Http;
using MoBaEsport.APIServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddTransient<IUserAPI, UserAPI>();
builder.Services.AddTransient<IPostAPI, PostAPI>();
builder.Services.AddTransient<IRelationshipAPI, RelationshipAPI>();
builder.Services.AddTransient<IChatBoxAPI, ChatBoxAPI>();

builder.Services.AddScoped<IValidator<LoginRequestModel>, LoginValidator>();
builder.Services.AddScoped<IValidator<RegisterRequestModel>, RegisterValidator>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
        options.AccessDeniedPath = "/User/Forbidden/";
    });


//Razor Runtime
var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}


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

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
