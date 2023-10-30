using PillPall.Views;

namespace PillPall;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(DrugItemPage), typeof(DrugItemPage));
        Routing.RegisterRoute(nameof(DateItemPage), typeof(DateItemPage));
    }
}

