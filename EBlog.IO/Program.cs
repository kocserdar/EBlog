using EBlog.Core.Entities;
using EBlog.Repo.Concretes;
using EBlog.Repo.Contexts;
using EBlog.Repo.Interfaces;
using EBlog.Service.Mapping;
using EBlog.Service.Services.AppUserServices;
using EBlog.Service.Services.ArticleServices;
using EBlog.Service.Services.GenreServices;
using EBlog.Service.Services.LikeServices;
using EBlog.Service.Utilities.UnitOfWorks;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<AppDbContext>();

//Mapping
builder.Services.AddAutoMapper(typeof(Mapping));

//Identity Service
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 3;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//Repos
builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<ILikeRepo, LikeRepo>();
builder.Services.AddScoped<IArticleRepo, ArticleRepo>();

//Services
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IArticleServices, ArticleServices>();
builder.Services.AddScoped<ILikeServices, LikeServices>();

//UnitOfWorks
builder.Services.AddTransient<IUnitOfWorks, UnitOfWorks>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
