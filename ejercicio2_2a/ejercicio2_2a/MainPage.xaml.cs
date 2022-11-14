using ejercicio2_2a.Models;
using ejercicio2_2a.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace ejercicio2_2a
{
    public partial class MainPage : ContentPage
    {
        Byte[] resultBase;

        public MainPage()
        {
            InitializeComponent();
           
        }

       

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.Listas());
        }


        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (Sign.IsBlank)
            {
                Message("Ingresar Firma en el cuadro blanco.");
                return;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Message("Campos Vacios, favor completar.");
                return;
            }


            //Para limpiar -- Sign.Clear();
            Stream img = await Sign.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)img;
            Byte[] bytes = mStream.ToArray();
            var signature = new Signature()
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Descripcion= txtDescripcion.Text,
                ArrayByteImage = bytes
            };


            var folderPath = "/storage/emulated/0/Android/data/com.companyname.ejercicio2_2a/files/Pictures";
            var nameSignature = "";
            if (await new serviciosfirmas().saveSignatures(signature))
            {

                try
                {
                   

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);



                    nameSignature = txtNombre.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                    File.WriteAllBytes(folderPath + "/" + nameSignature + ".png", signature.ArrayByteImage);

                    Message("Datos Ingresados correctamente en el directorio!! \nPath:" + folderPath + "/" + nameSignature + ".png");
                    clear();
                }
                catch
                {
                    Message("La firma se guardo correctamente!!");
                }



               
            }
            
            else Message("La firmar no se pudo guardar correctamente!!");

        }


        private void clear()
        {
            txtNombre.Text = null;
            txtDescripcion.Text = null;

            Sign.Clear();
        }

        public async void Message(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

    }
}

