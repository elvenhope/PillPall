namespace PillPall.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        cal.SelectedDate = DateTime.Today;
	}

    void cal_OnDateSelected(System.Object sender, System.DateTime e)
    {
    }
}
