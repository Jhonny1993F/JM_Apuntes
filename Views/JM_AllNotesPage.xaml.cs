namespace JM_Apuntes.Views;

public partial class JM_AllNotesPage : ContentPage
{
    public JM_AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new Models.JM_AllNotesPage();
    }

    protected override void OnAppearing()
    {
        ((Models.JM_AllNotesPage)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JM_NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.JM_Notes)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(JM_NotePage)}?{nameof(JM_NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}