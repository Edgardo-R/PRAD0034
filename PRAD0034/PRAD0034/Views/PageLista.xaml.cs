using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRAD0034.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRAD0034.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLista : ContentPage
    {
        public PageLista()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaPagos.ItemsSource = await DateBase.ObtenerListaPagos();
        }
    }
}