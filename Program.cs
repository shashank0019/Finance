using Finance.BusinessLogic;
using Finance.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Register dependencies (DI)
builder.Services.AddScoped<FinanceDataAccess>();
builder.Services.AddScoped<FinanceBusinessLogic>();

// ✅ Allow CORS (optional, but useful for frontend like React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// ✅ Build the app
var app = builder.Build();

// ✅ Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ Enable middleware
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// ✅ Run the app
app.Run();
