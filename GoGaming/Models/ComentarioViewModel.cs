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

        [Display(Prompt = "Comentario", Description = "Comentario", Name = "Contenido")]
        [Required(ErrorMessage = "Debe escribir un comentario")]
        [StringLength(maximumLength: 400, ErrorMessage = "El comentario no puede tener más de 400 caracteres")]
        public string Contenido { get; set; }

        [Display(Prompt = "Fecha y hora", Description = "Fecha y hora", Name = "Hora")]
        [Required(ErrorMessage = "Debe escribir una fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Hora { get; set; }
        
        
    }
}