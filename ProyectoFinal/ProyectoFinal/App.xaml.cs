using System;
using ProyectoFinal.Vistas;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioSesion());
        }
        public static MasterDetailPage MasterDet { get; set; }
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
