using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvalDanielLewensztain.Models
{
    public class Countries
    {

        [Required]
        [Display(Name ="País")]
        public string Pais { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Capital { get; set; }


        [Required]
        [Display(Name ="Cantidad de habitantes" )]
        public int Population { get; set; }

        
        [Display(Name = "Latitud y Longitud")]
        [DisplayFormat(DataFormatString ="{Lat=nn/Lon=nn}" , ApplyFormatInEditMode = true)]
        [Range(-180, 180, ErrorMessage = "Please enter correct value")]

        public int Latlng { get; set; }


        [Display(Name ="Zona Horaria")]
        [DataType((DataType.Time))]
        public DateTime TimeZone  { get; set; }

        
        [StringLength(15, MinimumLength = 4)]
        [Display(Name ="Moneda")]
        public string Currencies{ get; set; }


        [Required]
        public int PostalCode { get; set; }






    }
}