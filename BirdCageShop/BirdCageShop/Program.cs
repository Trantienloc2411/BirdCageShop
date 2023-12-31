using BirdCageShop.wwwroot.UploadService;
using DataAccessObjects;
using Microsoft.AspNetCore.Localization;
using Repository;
using System.Globalization;

namespace BirdCageShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            builder.Services.AddLogging();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IRevenueRepository, RevenueRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IUploadService, LocalFileUploadService>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IAccessoryRepository, AccessoryRepository>();

            builder.Services.AddScoped<UserDAO>();
            builder.Services.AddScoped<ProductDAO>();
            builder.Services.AddScoped<CategoryDAO>();
            builder.Services.AddScoped<DiscountDAO>();
            builder.Services.AddScoped<OrderDAO>();
            builder.Services.AddScoped<RevenueDAO>();
            builder.Services.AddScoped<FeedbackDAO>();
            builder.Services.AddScoped<OrderDetailDAO>();
            builder.Services.AddScoped<AccessoryDAO>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseSession();

            app.MapRazorPages();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("vi-VN"),
                SupportedCultures = new List<CultureInfo> { new CultureInfo("vi-VN") },
                SupportedUICultures = new List<CultureInfo> { new CultureInfo("vi-VN") }
            });

            app.Run();
        }
    }
}