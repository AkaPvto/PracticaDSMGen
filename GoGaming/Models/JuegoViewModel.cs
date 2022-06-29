using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoGaming.Models
{
    public class JuegoViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Generos", Description = "Generos del juego", Name = "Generos")]
        public List<Boolean> Generos { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del juego", Name = "Nombre")]
        [Required(ErrorMessage = "Debe escribir el nombre del juego")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre del juego no puede tener mas de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripcion", Description = "Sinopsis del juego", Name = "Descripcion")]
        [Required(ErrorMessage = "Debes escribir una descripcion del juego")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripcion no puede tener mas de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Portada", Description = "Imagen correspondiente al juego", Name = "Portada")]
        [Required(ErrorMessage = "Debes indicar una imagen para el juego")]
        [StringLength(maximumLength: 100, ErrorMessage = "El nombre de la imagen no puede tener mas de 100 caracteres")]
        public string Portada { get; set; }



        
    }
}