using Microsoft.EntityFrameworkCore;
using ShopManagement.Data;
//using Microsoft.AspNetCore.Cors;


var builder = WebApplication.CreateBuilder(args);




// Step 1: Add CORS service to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://shop-management-xi.vercel.app") // Allow your frontend origin (Vue app)
              .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
              .AllowAnyHeader(); // Allow any headers (for headers like Content-Type, Authorization, etc.)
    });
});





// Add services
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=dpg-d05j1ca4d50c73f2opkg-a.singapore-postgres.render.com;Port=5432;Database=shop_db_frsc;Username=abhishek;Password=voUt0e1Kha4pvQsKupY8Wt6eEeQ1F3Ry;SSL Mode=Require;Trust Server Certificate=true;"));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Step 2: Use CORS policy in your app.
app.UseCors("AllowSpecificOrigin");

// Conditionally use HTTPS redirection based on the environment
if (!app.Environment.IsDevelopment())  // Disable for production if Render handles HTTPS
{
    app.UseHttpsRedirection();
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World !!");


// ✅ Important Step: Bind to 0.0.0.0 and dynamic PORT
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();

