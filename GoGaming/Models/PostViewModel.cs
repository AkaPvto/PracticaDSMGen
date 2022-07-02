using PracticaDSMGenNHibernate.Enumerated.DSMPracticas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoGaming.Models
{
    public class PostViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Contenido", Description = "Contenido del post", Name = "Contenido")]
        [Required(ErrorMessage = "El contenido del post no puede estar vacío")]
        [StringLength(maximumLength: 800, ErrorMessage = "El post no puede tener más de 800 caracteres")]
        public string Contenido { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Categoria", Description = "Categoría del Post", Name = "Categoria")]
        public int Categoria { get; set; }

        [Display(Prompt = "Título del post", Description = "Título del post", Name = "Titulo")]
        [Required(ErrorMessage = "El post debe tener un título")]
        [StringLength(maximumLength: 30, ErrorMessage = "El título del post no puede tener más de 30 caracteres")]
        public string Titulo { get; set; }

        [Display(Prompt = "Imagen del post", Description = "Imagen del post", Name = "Imagen")]
        public string Imagen { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Hora { get; set; }

        [ScaffoldColumn(false)]
        public int Likes { get; set; }

    }
}