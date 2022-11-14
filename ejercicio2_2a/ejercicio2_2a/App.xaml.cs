using ejercicio2_2a.Servicios;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ejercicio2_2a
{
    public partial class App : Application
    {
        static basededatos db;


        public static basededatos DBase
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Signature.db3");

                    db = new basededatos(folderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();


            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());

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
