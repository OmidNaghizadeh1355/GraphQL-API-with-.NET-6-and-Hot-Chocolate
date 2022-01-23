using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
IWebHostEnvironment webHostEnvironment = builder.Environment;
IHostEnvironment hostEnvironment = builder.Environment;

#region Configure Services
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    configuration.GetConnectionString("CommandConStr")
));

#endregion
var app = builder.Build();

#region Configure the HTTP request pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

#endregion

app.Run();
