using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    public class Alumno
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; } 
        public string Municipio { get; set; }
        public string EstadoCivil { get; set; }
        public int Telefono { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Foto { get; set; }

        
        


    }
}
