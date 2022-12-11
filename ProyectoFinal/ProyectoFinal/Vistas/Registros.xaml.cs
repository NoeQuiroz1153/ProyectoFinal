using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

       



        private void ListadoA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ListadoA.ItemsSource = ListadoA.Where(s => s.Nombres.StarWith(e.NewTextValue));
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