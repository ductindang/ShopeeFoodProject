using BusinessLogicLayerFront.Services;
using BusinessLogicLayerFront.ServicesInterface;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Read from configuration (appsettings.json)
var httpClientBaseAddress = builder.Configuration.GetSection("HttpClientSettings:BaseAddress").Value;
var allowedCorsOrigin = builder.Configuration.GetSection("AllowedCorsOrigin").Value;

// Add session configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add HttpClient services
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IUserAddressService, UserAddressService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<ISubCategoryService, SubCategoryService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IProvinceService, ProvinceService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IStoreService, StoreService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IDiscountService, DiscountService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IDistrictService, DistrictService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IWardService, WardService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IMenuService, MenuService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});
builder.Services.AddHttpClient<IOrderDetailService, OrderDetailService>(client =>
{
    client.BaseAddress = new Uri(httpClientBaseAddress);
});

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins(allowedCorsOrigin)
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Use CORS
app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
