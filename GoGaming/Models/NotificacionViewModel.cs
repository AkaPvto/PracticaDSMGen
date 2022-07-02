using PracticaDSMGenNHibernate.Enumerated.DSMPracticas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoGaming.Models
{
    public class NotificacionViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Texto de la notificacion", Description = "Texto de la notificacion", Name = "Texto")]
        [Required(ErrorMessage = "La notificacion debe contener algun texto")]
        [StringLength(maximumLength: 800, ErrorMessage = "La notificacion no puede tener más de 800 caracteres")]
        public string Texto { get; set; }


        [ScaffoldColumn(false)]
        public DateTime Hora { get; set; }

    }
}