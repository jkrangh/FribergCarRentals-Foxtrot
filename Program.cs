using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FribergCarRentals_Foxtrot.Data;
namespace FribergCarRentals_Foxtrot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FoxtrotContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FoxtrotContext") ?? throw new InvalidOperationException("Connection string 'FoxtrotContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddTransient<ICar,CarRepository>();
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
            //Random kommentar
            app.UseRouting();
            //test samma rad
            //kommentar
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}