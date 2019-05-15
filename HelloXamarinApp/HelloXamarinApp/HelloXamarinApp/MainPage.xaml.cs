using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloXamarinApp
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }

            btnSave.Clicked += BtnSave_Clicked;
            btnDelete.Clicked += BtnDelete_Clicked;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }
    }
}
