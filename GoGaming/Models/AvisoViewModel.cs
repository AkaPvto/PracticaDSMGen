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
        public int id { get; set; }

        [Display(Prompt = "Texto del aviso", Description = "Texto del aviso indicando el motivo", Name = "Texto ")]
        [Required(ErrorMessage = "El aviso debe tener un texto explicando su motivo")]
        [StringLength(maximumLength: 100, ErrorMessage = "El texto del aviso no puede tener más de 100 caracteres")]
        public string Texto { get; set; }

        [Display(Prompt = "Usuario del aviso", Description = "Usuario al que se le manda el aviso", Name = "Usuario ")]
        [Required(ErrorMessage = "El aviso debe tener un usuario asociado")]
        [StringLength(maximumLength: 100, ErrorMessage = "El usuario del aviso no puede tener más de 100 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El aviso debe tener una hora asociada")]
        [DataType(DataType.Time, ErrorMessage = "La hora debe ser en formato HH:mm:ss")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Prompt = "Hora del aviso", Description = "Hora en la que se manda el aviso", Name = "Hora ")]

        public DateTime hora { get; set; }

    }
}