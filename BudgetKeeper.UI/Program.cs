using BudgetKeeper.UI.Services;
using Serilog;


namespace BudgetKeeper.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");

                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                builder.Services.AddRazorPages();
                builder.Services.AddServerSideBlazor();

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var baseUrl = configuration.GetSection("ApiSettings")["BaseUrl"];

                builder.Services.AddHttpClient("BudgetKeeperApi", client =>
                {
                    client.BaseAddress = new Uri(baseUrl);
                });
                builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BudgetKeeperApi"));

                builder.Services.AddSingleton(Log.Logger);

                builder.Services.AddScoped<CategoryService>();
                builder.Services.AddScoped<TransactionService>();
                builder.Services.AddScoped<ReportService>();

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

                app.MapBlazorHub();
                app.MapFallbackToPage("/_Host");

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
