using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using GoGaming.Models;

namespace GoGaming.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.Id = en.Id;
            usu.Nickname = en.Nickname;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Email = en.Email;
            usu.Direccion = en.Direccion;
            usu.Telefono = en.Telefono;
            usu.Foto = en.Foto;
            usu.Password = en.Pass;
            usu.Baneado = en.Baneado;
            usu.Admin = en.Administrator;

            return usu;
        }

        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach(UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }
    }
}