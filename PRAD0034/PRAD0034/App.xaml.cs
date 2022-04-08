using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PRAD0034.Views;
using PRAD0034.Controllers;

namespace PRAD0034
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateBase.Conexion(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DBPR.db3"));

            MainPage = new NavigationPage(new PageInicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
