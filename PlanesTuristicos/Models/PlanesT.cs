using System.Drawing;

namespace PlanesTuristicos.Models
{
    public class PlanesT
    {
        public int Id_PlanTuristicos { get; set; }

        public string Nombre_PlanTuristico { get; set; }

        public int? Rut {  get; set; }

        public string Municipio { get; set; }

        public double Precio {  get; set; } 

        public int? Actividades { get; set; }   

        public string? Duracion {  get; set; }  

        public string Informacion {  get; set; }   

    }
}
