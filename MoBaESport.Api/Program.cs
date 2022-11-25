using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoBaEsport.Application.Model.ChatBoxModel;
using MoBaEsport.Application.Model.CommentModel;
using MoBaEsport.Application.Model.FollowModel;
using MoBaEsport.Application.Model.FriendModel;
using MoBaEsport.Application.Model.GameModel;
using MoBaEsport.Application.Model.MessageModel;
using MoBaEsport.Application.Model.PostModel;
using MoBaEsport.Application.Model.ReactionModel;
using MoBaEsport.Application.Model.ReplyModel;
using MoBaEsport.Application.Systems.FileStorageService;
using MoBaEsport.Application.Systems.UserServiceModel;
using MoBaEsport.Data.DBContextModel;
using MoBaEsport.Data.EntityModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ESportDbContext");

// Add services to the container.
builder.Services.AddDbContext<ESportDbContext>(options =>
   options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<ESportDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => {
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

// Trasient services
builder.Services.AddTransient<IPublicPost, PublicPost>();
builder.Services.AddTransient<IManageComment, ManageComment>();
builder.Services.AddTransient<IManageReply, ManageReply>();
builder.Services.AddTransient<IManageReaction, ManageReaction>();
builder.Services.AddTransient<IManageChatBox, ManageChatBox>();
builder.Services.AddTransient<IManageMessage, ManageMessage>();
builder.Services.AddTransient<IManageFollow, ManageFollow>();
builder.Services.AddTransient<IManageFriend, ManageFriend>();
builder.Services.AddTransient<Microsoft.AspNetCore.Identity.UserManager<AppUser>, Microsoft.AspNetCore.Identity.UserManager<AppUser>>();
builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IManageGame, ManageGame>();

builder.Services.AddTransient<IValidator<LoginRequestModel>, LoginValidator>();

builder.Services.AddSwaggerGenNewtonsoftSupport();

//Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MoBaESport Api",
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
       Description = @"JWT Authorization header using the Bearer scheme. Example: \""Authorization: Bearer {token}\",
       Name = "Authorization",
       In = ParameterLocation.Header,
       Type = SecuritySchemeType.Http,
       Scheme = "Bearer" 
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

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

app.UseRouting();

app.UseAuthorization();

// Use Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MoBaESport v1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
