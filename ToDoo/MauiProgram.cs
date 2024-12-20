using Microsoft.Extensions.Logging;
using ToDoo.Repositories;

namespace ToDoo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<ITodoRepository, TodoRepository>();
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder muuiAppBuilder)
        {
            muuiAppBuilder.Services.AddTransient<ViewModels.MainViewModel>();
            muuiAppBuilder.Services.AddTransient<ViewModels.ItemViewModel>();
            return muuiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder muuiAppBuilder)
        {
            muuiAppBuilder.Services.AddTransient<Views.MainView>();
            muuiAppBuilder.Services.AddTransient<Views.ItemView>();
            return muuiAppBuilder;
        }
    }
}
