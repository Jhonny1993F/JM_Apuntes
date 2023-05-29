namespace JM_Apuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.JM_NotePage), typeof(Views.JM_NotePage));
    }
}
