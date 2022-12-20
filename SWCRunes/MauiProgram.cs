using Microsoft.Extensions.Logging;

namespace SWCRunes;

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
		//

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<RecommendationInventoryViewModel>();
        mauiAppBuilder.Services.AddSingleton<RequestInventoryViewModel>();
        mauiAppBuilder.Services.AddSingleton<RuneInventoryViewModel>();
		mauiAppBuilder.Services.AddSingleton<MonsterInventoryViewModel>();
        
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
		mauiAppBuilder.Services.AddSingleton<OptimizationService>();
        mauiAppBuilder.Services.AddSingleton<StorageService>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<RecommendationInventory>();
        mauiAppBuilder.Services.AddSingleton<MonsterInventory>();
        mauiAppBuilder.Services.AddSingleton<RuneInventory>();
        mauiAppBuilder.Services.AddSingleton<RequestInventory>();
        return mauiAppBuilder;
    }
}

