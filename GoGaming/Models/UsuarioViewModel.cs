using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GoGaming.Models
{
    public class UsuarioViewModel 
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de usuario", Description = "Nombre de usuario", Name = "Nickname ")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [StringLength(25, MinimumLength= 4, ErrorMessage = "El nombre de usuario debe tener entre 4 y 25 caracteres. ")]
        public string Nickname { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre real del usuario", Name = "Nombre ")]
        [Required(ErrorMessage = "El usuario debe tener un nombre")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos", Description = "Apellidos del usuario", Name = "Apellidos ")]
        [Required(ErrorMessage = "El usuario debe tener al menos un apellido")]
        [StringLength(500, MinimumLength = 6, ErrorMessage = "El apellido debe tener al menos 6 caracteres")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Email del usuario", Description = "Email del usuario", Name = "Email ")]
        [Required(ErrorMessage = "El email es obligatorio")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "Número de teléfono", Description = "Teléfono del usuario", Name = "Teléfono ")]
        public int Telefono { get; set; }

        [Display(Prompt = "Dirección del usuario", Description = "Dirección del usuario", Name = "Dirección ")]
        [StringLength(maximumLength: 500, ErrorMessage = "La dirección no puede tener más de 500 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Foto de perfil", Description = "Foto de perfil del usuario", Name = "Foto ")]
        //[Required(ErrorMessage = "El aviso debe tener un texto explicando su motivo")]
        [StringLength(maximumLength: 3000, ErrorMessage = "La ruta de la imagen es inaccesible")]
        public string Foto { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña del usuario", Name = "Password ")]
        [Required(ErrorMessage = "El campo contraseña no puede estar vacío")]
        [StringLength(64, MinimumLength = 4, ErrorMessage = "La contraseña debe tener entre 8 y 64 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ScaffoldColumn(false)]
        public bool Baneado { get; set; }
    }
}