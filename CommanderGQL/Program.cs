using CommanderGQL.Data;
using CommanderGQL.GraphQL;
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
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();


#endregion
var app = builder.Build();

#region Configure the HTTP request pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseRouting();

app.UseEndpoints( endpoints =>
{
    endpoints.MapGraphQL();
});

#endregion

app.Run();
