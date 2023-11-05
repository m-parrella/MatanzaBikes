using MatanzaBikes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MatanzaBikes.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// CRUD
//builder.Services.AddDbContext<WebMotosContext>(options =>
//    options.UseSqlServer("Data Source=LAPTOP-QA3T2VH6\\SQLEXPRESS;Initial Catalog=WebMotos;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddDbContext<MatanzaBikesContext>(options =>
    options.UseSqlServer("Name=MatanzaBikes:ConnectionString"));


// Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
   c.EnableAnnotations();
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MatanzaBikes.xml");
    c.IncludeXmlComments(filePath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
