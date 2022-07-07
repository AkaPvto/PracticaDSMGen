using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GoGaming.Models
{
    public class AvisoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Texto del aviso", Description = "Texto del aviso indicando el motivo", Name = "Texto ")]
        [Required(ErrorMessage = "El aviso debe tener un texto explicando su motivo")]
        [StringLength(maximumLength: 100, ErrorMessage = "El texto del aviso no puede tener más de 100 caracteres")]
        public string Texto { get; set; }

        //[Display(Prompt = "Usuario del aviso", Description = "Usuario al que se le manda el aviso", Name = "Usuario ")]
        //[Required(ErrorMessage = "El aviso debe tener un usuario asociado")]
        //[StringLength(maximumLength: 100, ErrorMessage = "El usuario del aviso no puede tener más de 100 caracteres")]
        //public string Usuario { get; set; }

        [ScaffoldColumn(false)]

        public DateTime Hora { get; set; }

    }
}