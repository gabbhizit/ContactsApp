namespace ContactsAppMaui.Views.Controls;

public partial class ContactControl : ContentView
{
	public event EventHandler<string> OnError;
	public event EventHandler<EventArgs> OnSave;
	public event EventHandler<EventArgs> OnCancel;
	public ContactControl()
	{
		InitializeComponent();
	}
	public string Name
	{
		get
		{
			return EntryName.Text;
		}
		set
		{
			EntryName.Text = value;
		}
	}
	public string Phone
	{
		get
		{
			return EntryPhone.Text;
		}
		set { EntryPhone.Text = value; }
	}
	public string Address
	{
		get {
			return EntryAddress.Text;
		}
		set { EntryAddress.Text = value; }
	}
	public string Email
	{
		get
		{
			return EntryEmail.Text;
		}
		set
		{
			EntryEmail.Text = value;
		}
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required.");
            return;
        }
        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }
            return;
        }
		OnSave?.Invoke(sender, e);

    }

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);

    }
}