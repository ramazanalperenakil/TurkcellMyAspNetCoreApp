using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IHelper, Helper>();
//builder.Services.AddScoped<IHelper, Helper>();
//builder.Services.AddTransient<IHelper, Helper>(sp =>
//{
//    return new Helper(true);
//}


//);
builder.Services.AddScoped<Helper>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
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

//app.MapControllerRoute(
//    name: "article",
//    pattern: "{controller=Blog}/{action=Article}/{name}/{id}");
//app.MapControllerRoute(
//    name: "blog",
//pattern: "blog/{*article}",
//    defaults: new { controller = "Blog", Action="Article" });


//app.MapControllerRoute(
//    name: "productpages",
//    pattern: "{controller=Products}/{action=pages}/{page}/{pageSize}");


//app.MapControllerRoute(
//    name: "productgetbyid",
//    pattern: "{controller=Products}/{action=GetById}/{productid}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

//baseUrl/ürünler/kalem/1
// baseUrl/home/index
//baseUrl/home/privacy

//https://localhost:7098/
//https://www.mysite.com
app.Run();
