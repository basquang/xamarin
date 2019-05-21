using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselPivotApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : CarouselPage
    {
        ObservableCollection<MyClass> AllDays = new ObservableCollection<MyClass>();
        public MainPage()
        {
            InitializeComponent();
            //AllDays.Add(new MyClass { MyProperty = DateTime.Now.AddDays(-1) });
            AllDays.Add(new MyClass { MyProperty = DateTime.Now });
            AllDays.Add(new MyClass { MyProperty = DateTime.Now.AddDays(1) });
            CurrentPageChanged += MainPage_CurrentPageChanged;
            ItemsSource = AllDays;
        }

        private void MainPage_CurrentPageChanged(object sender, EventArgs e)
        {
            var currentIndex = Children.IndexOf(CurrentPage);

            if (currentIndex == 0)
            {
                AllDays.Insert(0, new MyClass { MyProperty = AllDays[currentIndex].MyProperty.AddDays(-1) });
            }
            if (currentIndex == Children.Count - 1)
            {
                AllDays.Add(new MyClass { MyProperty = AllDays[currentIndex].MyProperty.AddDays(1) });
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();            
            CurrentPage = Children[1];
        }
    }
    public class MyClass
    {
        public DateTime MyProperty { get; set; }
    }
}
