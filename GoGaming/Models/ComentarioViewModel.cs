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

        [ScaffoldColumn(false)]
        public DateTime Hora { get; set; }
        
        
    }
}