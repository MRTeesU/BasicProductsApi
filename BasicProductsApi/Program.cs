using BasicProductsApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task<List<Product>> GetAllProducts(ProductContext context) => await context.Products.ToListAsync();

app.MapGet("/", () => "This is a test message");

app.MapGet("/products", async (ProductContext context) => await context.Products.ToListAsync());

app.MapGet("/products/{id}", async (ProductContext context, int id) =>
    await context.Products.FindAsync(id) is Product product ?
        Results.Ok(product) :
        Results.NotFound("No product found"));

app.MapPost("/product", async (ProductContext context, Product product) =>
{
    context.Products.Add(product);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllProducts(context));
});
app.MapPut("/product/{id}", async (ProductContext context, Product product, int id) =>
{
    var dbProduct = await context.Products.FindAsync(id);
    if (dbProduct == null) return Results.NotFound("No product found");

    //dbProduct.ProductId = product.ProductId;
    dbProduct.Name = product.Name;
    dbProduct.Description = product.Description;
    dbProduct.Price = product.Price;
    dbProduct.InStock = product.InStock;
    await context.SaveChangesAsync();

    return Results.Ok(await GetAllProducts(context));
});

app.MapDelete("/product/{id}", async (ProductContext context, int id) =>
{
    var dbProduct = await context.Products.FindAsync(id);
    if (dbProduct == null) return Results.NotFound("no");

    context.Products.Remove(dbProduct);
    await context.SaveChangesAsync();

    return Results.Ok(await GetAllProducts(context));
});

app.Run();
