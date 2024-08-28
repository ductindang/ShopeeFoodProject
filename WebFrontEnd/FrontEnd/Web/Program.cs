using BusinessLogicLayerFront.Services;
using BusinessLogicLayerFront.ServicesInterface;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<ISubCategoryService, SubCategoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<IProvinceService, ProvinceService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<IStoreService, StoreService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<IDiscountService, DiscountService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});

builder.Services.AddHttpClient<IDistrictService, DistrictService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7239/");
});


// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
