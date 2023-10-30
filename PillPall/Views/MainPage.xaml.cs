using PillPall.ViewModels;

namespace PillPall.Views;

public partial class MainPage : ContentPage
{
    private MainViewModel VM;

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        VM = vm;
        Cal.SelectedDate = DateTime.Today;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await VM.getSpecificDates();
    }

    async void Cal_OnDateSelected(System.Object sender, System.DateTime e)
    {
        await VM.getSpecificDates();
    }
}
