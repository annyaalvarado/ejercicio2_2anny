using ejercicio2_2a.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ejercicio2_2a.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listas : ContentPage
    {
        public Listas()
        {
            InitializeComponent();

            if (App.DBase == null)
            {

            }

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            list.ItemsSource = await new serviciosfirmas().GetSignatures();
        }

        private void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }
    }
}