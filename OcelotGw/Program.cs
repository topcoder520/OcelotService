using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            //Ocelot配置
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
            builder.Services.AddOcelot(configuration);

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            //Ocelot加入管道
            app.UseOcelot().Wait();

            app.Run();
        }
    }
}
