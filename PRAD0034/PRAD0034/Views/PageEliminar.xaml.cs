using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRAD0034.Controllers;
using PRAD0034.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PRAD0034.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEliminar : ContentPage
    {
        public PageEliminar()
        {
            InitializeComponent();
        }
        private async Task<bool>ValidarID()
        {
            if (string.IsNullOrWhiteSpace(id_pago.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo ID Pago es Obligatorio", "Aceptar");
                return false;
            }
            return true;
        }
        private async void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            if (await ValidarID())
            {
                await DisplayAlert("Exito", "ID Correcta", "Aceptar");
                var pago = new Pagos
                {
                    Id_pago = Convert.ToInt32(id_pago.Text),
                };
                await DateBase.DelPago(pago);
                if (await DateBase.DelPago(pago) == 0)
                {
                    await DisplayAlert("Aviso", "Eliminado Exitoso", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Alerta", "Error al Eliminar", "Aceptar");
                }
                id_pago.Text = "";
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listaPagos.ItemsSource = await DateBase.ObtenerListaPagos();
        }
    }
}