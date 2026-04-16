using Pharmacy.API.Data;
using Pharmacy.API.Extensions;
using Pharmacy.API.Middleware;
using Pharmacy.API.Repositories;
using Pharmacy.API.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Core Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// 2. Register Extensions (Clean Architecture & Config)
builder.Services.ConfigureMySql(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureCors();
builder.Services.ConfigureSwagger();

// 3. Register ALL Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<ILoyaltyRepository, LoyaltyRepository>();
builder.Services.AddScoped<IHealthPackageRepository, HealthPackageRepository>();

// 4. Register ALL Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<ILoyaltyService, LoyaltyService>();

var app = builder.Build();

// 5. Configure HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global Exception Handling
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

// Enable CORS for Angular (localhost:4200)
app.UseCors("AllowAngularApp");

// Authentication & Authorization (JWT)
app.UseAuthentication();
app.UseAuthorization();

// Serve static files (wwwroot/uploads for prescriptions)
app.UseStaticFiles();

app.MapControllers();

app.Run();