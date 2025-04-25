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



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World !!");

app.Run();