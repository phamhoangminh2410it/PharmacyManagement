using Microsoft.EntityFrameworkCore;
using PharmacyManagement.Models.Entities;
using PharmacyManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPositionServices, PositionServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IPaymentSlipServices, PaymentSlipServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IStaffServices, StaffServices>();
builder.Services.AddScoped<ISupplierServices, SupplierServices>();
builder.Services.AddScoped<IImportSlipServices, ImportSlipServices>();
builder.Services.AddScoped<IImportSlipDetailServices, ImportSlipDetailServices>();
builder.Services.AddScoped<IExportSlipServices, ExportSlipServices>();
builder.Services.AddScoped<IExportSlipDetailServices, ExportSlipDetailServices>();
builder.Services.AddScoped<IProductSaleSlipServices, ProductSaleSlipServices>();
builder.Services.AddScoped<IProductSaleSlipDetailServices, ProductSaleSlipDetailServices>();
builder.Services.AddScoped<IReturnSlipServices, ReturnSlipServices>();
builder.Services.AddScoped<IInventorySlipServices, InventorySlipServices>();
builder.Services.AddScoped<IInventorySlipDetailServices, InventorySlipDetailServices>();

builder.Services.AddDbContext<PharmacyManagementContext>(c =>
        c.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");*/

app.MapControllerRoute(
    name: "staff",
    pattern: "{controller=Staff}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "supplier",
    pattern: "{controller=Supplier}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "paymentslip",
    pattern: "{controller=PaymentSlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "position",
    pattern: "{controller=Position}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "category",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "importslip",
    pattern: "{controller=ImportSlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "importslipdetail",
    pattern: "{controller=ImportSlipDetail}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "exportslip",
    pattern: "{controller=ExportSlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "exportslipdetail",
    pattern: "{controller=ExportSlipDetail}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "productsaleslip",
    pattern: "{controller=ProductSaleSlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "productsaleslipdetail",
    pattern: "{controller=ProductSaleSlipDetail}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "returnslip",
    pattern: "{controller=ReturnSlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "inventoryslip",
    pattern: "{controller=InventorySlip}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "inventoryslipdetail",
    pattern: "{controller=InventorySlipDetail}/{action=Index}/{id?}");

app.Run();
