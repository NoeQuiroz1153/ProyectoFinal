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
    public partial class InicioSesion : ContentPage
    {
        public InicioSesion()
        {
          InitializeComponent();
        }

     

        private async void Button_Clicked(object sender, EventArgs e)
        {
            String usuario = User.Text;
            String contraseña = Contra.Text;

            if ((usuario == "Admin") && (contraseña == "root"))
            {
                Navigation.PushAsync(new MainPage());
                
            }
            else
            {
                lblResultado.Text = "El usuario o contraseña son incorrectos!";
            }
           
        }
    }
}