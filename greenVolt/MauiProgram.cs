using Microsoft.Extensions.Logging;
using AutoMapper;
using MauiIcons.Material;
using greenVolt.Services;
namespace greenVolt
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5005/"); 
                client.Timeout = TimeSpan.FromSeconds(30); 
            });

            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder
                .UseMauiApp<App>()
                .UseMaterialMauiIcons()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
