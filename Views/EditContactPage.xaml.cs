namespace ContactsAppMaui.Views;
using Contact = ContactsAppMaui.Models.Contact;
using ContactsAppMaui.Models;
[QueryProperty(nameof(contactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
    public EditContactPage()
	{
		InitializeComponent();
	}

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    public string contactId
    {
        set
        {
            contact = ContactsRepo.GetContatcById(int.Parse(value));
            if (contact != null )
            {
                EntryName.Text = contact.Name;
                EntryEmail.Text = contact.Email;
                EntryPhone.Text = contact.Phone;
                EntryAddress.Text = contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

    }
}