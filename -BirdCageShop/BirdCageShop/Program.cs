using BirdCageShop.wwwroot.UploadService;
using DataAccessObjects;
using Repository;

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

            builder.Services.AddScoped<UserDAO>();
            builder.Services.AddScoped<ProductDAO>();
            builder.Services.AddScoped<CategoryDAO>();
            builder.Services.AddScoped<DiscountDAO>();
            builder.Services.AddScoped<OrderDAO>();
            builder.Services.AddScoped<RevenueDAO>();
            builder.Services.AddScoped<FeedbackDAO>();
            builder.Services.AddScoped<OrderDetailDAO>();

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

            app.Run();
        }
    }
}