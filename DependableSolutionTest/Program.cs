using BLL.BLL.DependencyResolve;
using DependableSolutionTest.Factory;
using Utility.Utility.DependencyResolve;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ServiceDependency();
builder.Services.UtilityResolver();
builder.Services.AddSingleton<IOrderPurchaseFactory,OrderPurchaseFactory>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=OrderPurchase}/{action=OrderList}/{id?}");

app.Run();
