using HelloXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloXamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update
                File.WriteAllText(note.FileName, note.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }

            await Navigation.PopAsync();
        }
    }
}