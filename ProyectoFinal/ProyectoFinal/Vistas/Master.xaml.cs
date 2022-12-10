using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }


        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
           // App.MasterDet.IsPresented = false;
            await Navigation.PushAsync(new Addalumno());
        }

        private async void BtnLista_Clicked(object sender, EventArgs e)
        {
           // App.MasterDet.IsPresented = false;
            await Navigation.PushAsync(new Registros());

        }
        private async void BtnMenu_Clicked(object sender, EventArgs e)
        {

        }
             

        
    }
}