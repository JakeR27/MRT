using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MRT.Data;
using MRT.Data.ResultModels;

namespace MRT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<ResultsService>();
            var db = new CachedDatabase(LiteDb.Instance());
            builder.Services.AddSingleton(new PersistService(db));
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //PersistService.AddOrganiser(new Organiser {Id = Guid.NewGuid(), Name = "Club 100"});
            //DataSetup.Set();
            PersistService.Load();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}