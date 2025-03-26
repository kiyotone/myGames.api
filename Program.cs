using myGames.api.Data;
using myGames.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("myGamesDb");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGamesEndpoints();

await app.MigrateDbAsync();

app.Run();
