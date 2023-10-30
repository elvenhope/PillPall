using PillPall.Models;
using PillPall.ViewModels;

namespace PillPall.Views;

[QueryProperty(nameof(Item), "CurrentDate")]
public partial class DrugDateEntryItemPage : ContentPage
{
	DrugDateEntryViewModel VM;
    public DateItem Item { set => VM.Item = value; }


    public DrugDateEntryItemPage(DrugDateEntryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        VM = vm;
        //if (Item is not null)
        //{
        //    VM.CurrentDateItem = Item;
        //    VM.DayOfWeek = Item.DayOfWeek;
        //    VM.Time = Item.Time;
        //    VM.DrugID = Item.DrugID;
        //    VM.Dose = Item.Dose;
        //}
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (VM.Item is not null)
        {
            if (String.IsNullOrEmpty(VM.Item.DrugName))
            {
                CurSelectedDrug.Text = "";
            }
        }
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        //if (string.IsNullOrWhiteSpace(Item.DayOfWeek))
        //{
        //    await DisplayAlert("Name Required", "Please enter a name for the drug item.", "OK");
        //    return;
        //}

        //await database.SaveItemAsync(Item);
        //await Shell.Current.GoToAsync("..");
        await VM.OnSaveClicked();
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        //if (Item.ID == 0)
        //    return;
        //await database.DeleteItemAsync(Item);
        //await Shell.Current.GoToAsync("..");
        await VM.OnDeleteClicked();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    void RadioButton_CheckedChanged(Object sender, CheckedChangedEventArgs e)
    {
        RadioButton btn = (RadioButton)sender;
        VM.Item.DrugID = (int)btn.Value;
        VM.Item.DrugName = (string)btn.Content;
        CurSelectedDrug.Text = VM.Item.DrugName + " Is Currently Selected";
    }
}
