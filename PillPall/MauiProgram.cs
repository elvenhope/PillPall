using Microsoft.Extensions.Logging;
using PillPall.Data;
using PillPall.ViewModels;
using PillPall.Views;

namespace PillPall;

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
				//fonts.AddFont("YoungSerif-Regular.ttf", "YoungSerifRegular");
				fonts.AddFont("NanumGothic-Bold.ttf", "NanumGothicBold");
                fonts.AddFont("NanumGothic-Regular.ttf", "NanumGothicRegular");
                fonts.AddFont("NanumGothic-ExtraBold.ttf", "NanumGothicExtraBold");
            });

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<DateListPage>();
		builder.Services.AddTransient<DateItemPage>();

        builder.Services.AddSingleton<DrugListPage>();
        builder.Services.AddTransient<DrugItemPage>();

        builder.Services.AddSingleton<DrugItemDatabase>();
        builder.Services.AddSingleton<DateItemDatabase>();

		builder.Services.AddSingleton<DrugDateEntryPage>();
		builder.Services.AddSingleton<DrugDateEntryViewModel>();
		builder.Services.AddTransient<DrugDateEntryItemPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

