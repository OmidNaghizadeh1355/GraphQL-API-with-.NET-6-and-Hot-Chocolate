using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Flight;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using StarWarAPI.Core;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
IWebHostEnvironment webHostEnvironment = builder.Environment;
IHostEnvironment hostEnvironment = builder.Environment;

#region Configure Services
builder.Services.AddTransient<IStarWarApiService, StarWarApiService>();
builder.Services.AddTransient<IValidationResult, ValidationResult>();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
    configuration.GetConnectionString("CommandConStr")
));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<StarShipFlightType>()
    .AddType<StarShipType>()
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();


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

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
    
}, "/graphql-voyager");
#endregion

app.Run();
