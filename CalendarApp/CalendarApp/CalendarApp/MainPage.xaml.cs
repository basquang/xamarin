using Plugin.Calendars;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalendarApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await GetAppointments();           
        }
        async Task GetAppointments()
        {
            try
            {
                PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Calendar);
                if (status != PermissionStatus.Granted)
                {
                    //Will return false if calendar not added account
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Calendar))
                    {
                        await DisplayAlert("Need calendar access", "The app need access to calendar to display events", "OK");
                    }

                    //var openSettings = CrossPermissions.Current.OpenAppSettings();

                    var statuses = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Calendar);                   
                }

                if (status == PermissionStatus.Granted)
                {
                    //Query permission
                    var calendars = await CrossCalendars.Current.GetCalendarsAsync();
                    foreach(var calendar in calendars)
                    {
                        var events = await CrossCalendars.Current.GetEventsAsync(calendar, DateTime.Today, DateTime.Today.AddDays(1));
                        foreach(var appointment in events)
                        {
                            System.Diagnostics.Debug.WriteLine(appointment.Name);
                            System.Diagnostics.Debug.WriteLine(appointment.Description);
                        }
                        
                    }
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //location denied
                }
            }
            catch (Exception ex)
            {
                //Something went wrong
            }
        }
    }
}
