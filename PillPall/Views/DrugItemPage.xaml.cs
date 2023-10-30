using PillPall.Data;
using PillPall.Models;

namespace PillPall.Views;


[QueryProperty("Item", "Item")]
public partial class DrugItemPage : ContentPage
{
	//DrugItem item;

	public DrugItem Item
	{
		get => BindingContext as DrugItem;
		set => BindingContext = value;
	}

	DrugItemDatabase database;

	public DrugItemPage(DrugItemDatabase drugItemDatabase)
	{
		InitializeComponent();

		database = drugItemDatabase;
	}

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the drug item.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Item.Type))
        {
            await DisplayAlert("Type Required", "Please select a Type.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
