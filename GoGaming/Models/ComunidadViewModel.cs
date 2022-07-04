using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoGaming.Models
{
    public class ComunidadViewModel
    {

        [ScaffoldColumn(false)]
        public int CodigoComunidad { get; set; }

        [ScaffoldColumn(false)]
        public int Juego { get; set; }

        [Display(Prompt = "Juego de la comunidad", Description = "Juego de la comunidad", Name = "Juego")]
        [Required(ErrorMessage = "Debe indicar un juego para la comunidad")]
        [StringLength(maximumLength: 200, ErrorMessage = "El juego no puede tener más de 200 caracteres")]
        public string NomJuego { get; set; }

        [Display(Prompt = "Nombre de la comunidad", Description = "Nombre de la comunidad", Name = "Comunidad")]
        [Required(ErrorMessage = "Debe indicar un nombre para la comunidad")]
        [StringLength(maximumLength: 100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción de la comunidad", Description = "Descripción de la comunidad", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripción para la comunidad")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Prompt = "Fecha de creación de la comunidad", Description = "Fecha de creación de la comunidad", Name = "FechaCreación")]
        [DataType(DataType.Date, ErrorMessage = "La fecha debe ser en formato dd/MM/yyyy")]
        public DateTime FechaCreacion { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Portada", Description = "Imagen correspondiente a la comunidad", Name = "Portada")]
        public string Portada { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Miembros", Description = "Numero de miembros de la comunidad", Name = "Miembros")]
        public int Miembros { get; set; }
    }
}