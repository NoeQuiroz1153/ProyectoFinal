using Plugin.Media;
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
    public partial class Addalumno : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public Addalumno()
        {
            InitializeComponent();
        }

        Models.Alumno _Alumno;
        public Addalumno(Models.Alumno Alumno)
        {
            InitializeComponent();
             Title = "Editar Contacto";
            _Alumno = Alumno;
            nombres.Text = Alumno.Nombres;
            apellidos.Text = Alumno.Apellidos;
            fechanacimiento.Text = Convert.ToString(Alumno.FechaNacimiento);
            pais.Text = Alumno.Pais;
            departamento.Text = Alumno.Departamento;
            municipio.Text = Alumno.Municipio;
            estadocivil.Text = Alumno.EstadoCivil;
            telefono.Text = Convert.ToString(Alumno.Telefono);
            latitud.Text = Convert.ToString(Alumno.Latitud);
            longitud.Text= Convert.ToString(Alumno.Longitud);
           // foto =Convert.ToBase64String(Alumno.Foto);

      
            
        }


    private String traeImagenToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    string Base64String = Convert.ToBase64String(fotobyte);
                    return Base64String;
                }
            }
            return null;
        }

      


        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            {
                var alumn = new Models.Alumno

                {
                    Nombres = nombres.Text,
                    Apellidos = apellidos.Text,
                    FechaNacimiento = Convert.ToDateTime(fechanacimiento.Text),
                    Pais = pais.Text,
                    Departamento = departamento.Text,
                    Municipio = municipio.Text,
                    EstadoCivil = estadocivil.Text,
                    Telefono = Convert.ToInt32(telefono.Text),
                    Latitud = Convert.ToDouble(latitud.Text),
                    Longitud = Convert.ToDouble(longitud.Text),
                    //Foto = traeImagenToBase64(),
                };
                if (await Models.Cntrolcrud.CreateAlumno(alumn) > 0)
                {
                    await DisplayAlert("Alumno Creado", "El Alumno " + alumn.Nombres + "Ha sido creado", "OK");
                    await Navigation.PushAsync(new Registros());

                }
                else
                {
                    await Models.Cntrolcrud.EditarAlumnos(alumn);
                    await DisplayAlert("Alumno Actualizado", "El Alumno " + alumn.Nombres + "Ha sido Actualizado", "OK");
                    await Navigation.PushAsync(new Registros());
                //await DisplayAlert("Error", "El Alumno " + alumn.Nombres + "No se Ha sido creado", "OK");
            }
        }




        }
        

        private async void BtnFoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Capertafotos",
                Name = "Foto.jpg",
                SaveToAlbum = true
              });

            if(photo!=null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }


        }


       

     
    }
}