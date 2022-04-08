using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRAD0034.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInicio : ContentPage
    {
        public PageInicio()
        {
            InitializeComponent();
        }

        private async void btn_pago_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAgregar());
        }

        private async void btn_lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageLista());
        }

        private async void btn_del_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageEliminar());
        }

        private async void btn_mod_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageModificar());
        }
    }
}