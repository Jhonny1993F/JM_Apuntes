namespace JM_Apuntes.Views;

public partial class JM_AbautPage : ContentPage
{
	public JM_AbautPage()
	{
		InitializeComponent();
	}
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JM_Abaut abaut)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync("https://aka.ms/maui");
        }
    }
}