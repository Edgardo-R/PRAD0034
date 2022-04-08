using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRAD0034.Models;
using PRAD0034.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media;

namespace PRAD0034.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageModificar : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageModificar()
        {
            InitializeComponent();
        }
        private async Task<bool> ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(id_pago.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo ID Pago es Obligatorio", "Aceptar");
                return false;
            }
            if (String.IsNullOrWhiteSpace(descripcion.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo Descripcion esta vacio", "Aceptar");
                return false;
            }
            if (string.IsNullOrWhiteSpace(monto.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo Monto es Obligatorio", "Aceptar");
                return false;
            }
            return true;
        }
        private async void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            if (await ValidarDatos())
            {
                await DisplayAlert("Exito", "Datos Correctos", "Aceptar");
                var pago = new Pagos
                {
                    Id_pago = Convert.ToInt32(id_pago.Text),
                    Descripcion = descripcion.Text,
                    Monto = Convert.ToDouble(monto.Text),
                    Fecha = fecha.Date,
                    Photo_recibo = FotoDelPago(),
                };
                await DateBase.AddPago(pago);
                if (await DateBase.AddPago(pago) > 0)
                {
                    await DisplayAlert("Aviso", "Guardado Exitoso", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Alerta", "Error al Guardar", "Aceptar");
                }
                id_pago.Text = "";
                descripcion.Text = "";
                monto.Text = "";
            }
        }
        private Byte[] FotoDelPago()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }
        private async void btn_tomar_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "FotosApp",
                Name = "pago.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }
        }
    }
}