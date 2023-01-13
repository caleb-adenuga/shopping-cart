using Checkout.Data;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


string connectionstring = "Server=DESKTOP-LHSQMU9\\SQLEXPRESS01; Database=MyApp; Trusted_connection=true";


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
// if anyone asks for a BasketService give them one of the implementations
builder.Services.AddScoped<IBasketRepository, BasketRepository>(x => new BasketRepository(connectionstring));
builder.Services.AddScoped<IBasketItemsRepository, BasketItemsRepository>(x => new BasketItemsRepository(connectionstring));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
