using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registros : ContentPage
    {
        public Registros()
        {
            InitializeComponent();
             
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListadoA.ItemsSource= await Models.Cntrolcrud.GetAlumnos();
            
            
        }

        //public Image Base64ToImage(string base64String)
        //{
        //    // Convert base 64 string to byte[]
        //    byte[] imageBytes = Convert.FromBase64String(base64String);
        //    // Convert byte[] to Image
        //    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //    {
        //        Image image = Image.FromStream(ms, true);

        //        return image;
        //    }
        //}


        private void ListadoA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
         
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addalumno());
        }

        async void BtnEditar_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var contac = item.CommandParameter as Alumno;
            await Navigation.PushAsync(new Addalumno(contac));
        }

        async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var contac = item.CommandParameter as Alumno;
            
            var resultado = await DisplayAlert("Eliminar", $"Elimanando a {contac.Nombres} de la base de datos", "SI", "NO");
            if (resultado)
            {
                await Models.Cntrolcrud.EliminaAlumnos(contac.Id);
                await Navigation.PushAsync(new Registros());
            }


        }
    }
}