using EBlog.Repo.Concretes;
using EBlog.Repo.Contexts;
using EBlog.Repo.Interfaces;
using EBlog.Service.Mapping;
using EBlog.Service.Services.AppUserServices;
using EBlog.Service.Utilities.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DbContext
builder.Services.AddDbContext<AppDbContext>();

//Mapping
builder.Services.AddAutoMapper(typeof(Mapping));

//Repos
builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
builder.Services.AddScoped<IGenreRepo, GenreRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<ILikeRepo, LikeRepo>();
builder.Services.AddScoped<IArticleRepo, ArticleRepo>();

//Services


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
