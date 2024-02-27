using API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
WebApplication app = Startup.ConfigureWebApplication(builder);

app.Run();