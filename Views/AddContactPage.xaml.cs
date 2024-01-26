using ContactsAppMaui.Models;

namespace ContactsAppMaui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void contactCtrl_OnSave(object sender, EventArgs e)
    {
        ContactsRepo.AddContact(new Models.Contact
        {
            Name = contactCtrl.Name,
            Phone = contactCtrl.Phone,
            Email = contactCtrl.Email,
            Address = contactCtrl.Address,
        });
        Shell.Current.GoToAsync("..");

    }

    private void contactCtrl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e, "OK");
    }

    private void contactCtrl_OnCancel(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}