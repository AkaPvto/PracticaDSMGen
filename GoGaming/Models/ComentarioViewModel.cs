using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoGaming.Models
{
    public class ComentarioViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Autor", Description = "Autor del comentario", Name = "Autor")]
        public int Autor { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "nameAutor", Description = "Nombre del autor del comentairo", Name= "Nombre del autor")]
        public string nameAutor { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Post", Description = "Post al que pertenece el comentario", Name = "Post")]
        public int Post { get; set; }

        [Display(Prompt = "Comentario", Description = "Comentario", Name = "Contenido")]
        [Required(ErrorMessage = "Debe escribir un comentario")]
        [StringLength(maximumLength: 400, ErrorMessage = "El comentario no puede tener más de 400 caracteres")]
        public string Contenido { get; set; }

        [ScaffoldColumn(false)]
        //[Display(Prompt = "Fecha y hora", Description = "La fecha y la hora a la que se publico el comentario", Name = "Hora")]
        public DateTime Hora { get; set; }

        [ScaffoldColumn(false)]
        public int Hijos { get; set; }

        [ScaffoldColumn(false)]
        public bool Padre { get; set; }


    }
}