//using static Android.Content.ClipData;
namespace JM_Apuntes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class JM_NotePage : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }

    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public JM_NotePage()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));

        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }

    private async void JM_SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JM_Notes note)
            File.WriteAllText(note.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void JM_DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.JM_Notes note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void LoadNote(string fileName)
    {
        Models.JM_Notes noteModel = new Models.JM_Notes();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}