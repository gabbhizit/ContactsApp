using ContactsAppMaui.Models;
using System.Collections.ObjectModel;
using Contact = ContactsAppMaui.Models.Contact;


namespace ContactsAppMaui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
        

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }

    private void btnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));

    }

    private void btnEditContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditContactPage));
    }


    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem=sender as MenuItem;
        var contact=menuItem.CommandParameter as Contact;
        ContactsRepo.DeleteContact(contact.ContactId);
        LoadContacts();
    }
    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepo.GetContacts());
        SearchBar.Text=string.Empty;
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactsRepo.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }
}