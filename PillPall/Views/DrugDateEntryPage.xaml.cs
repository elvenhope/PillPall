using PillPall.Models;
using PillPall.ViewModels;

namespace PillPall.Views;

public partial class DrugDateEntryPage : ContentPage
{
	DrugDateEntryViewModel VM;

	public DrugDateEntryPage(DrugDateEntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		VM = vm;
	}


    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		await VM.getDrugs();
		await VM.getDates();
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        VM.Item = new DateItem();
        await Shell.Current.GoToAsync(nameof(DrugDateEntryItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new DateItem()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not DateItem item)
            return;

        await Shell.Current.GoToAsync(nameof(DrugDateEntryItemPage), true, new Dictionary<string, object>
        {
            ["CurrentDate"] = item
        });
    }
}
