using JM_Apuntes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Provider.ContactsContract.CommonDataKinds;

namespace JM_Apuntes.Models
{
    internal class JM_AllNotesPage
    {
        public ObservableCollection<JM_Notes> Notes { get; set; } = new ObservableCollection<JM_Notes>();

        public JM_AllNotesPage() =>
            LoadNotes();

        public void LoadNotes()
        {
            Notes.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<JM_Notes> notes = Directory

                                        // Select the file names from the directory
                                       .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new JM_Notes()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (JM_Notes note in notes)
                Notes.Add(note);
        }
    }
}
