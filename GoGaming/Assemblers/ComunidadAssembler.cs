using GoGaming.Models;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class ComunidadAssembler
    {
        public ComunidadViewModel ConvertENToModelUI(ComunidadEN en)
        {
            ComunidadViewModel com = new ComunidadViewModel();
            JuegoEN juegoEN = new JuegoCEN().ReadOID(en.Juego.Id);
            int miembros = new UsuarioCEN().GetUsuariosComunidad(en.Id).Count;

            com.CodigoComunidad = en.Id;
            com.Nombre = en.Nombre;

            com.Juego = en.Juego.Id;
            com.NomJuego = en.Juego.Nombre;

            com.Descripcion = en.Descripcion;
            com.FechaCreacion = (DateTime)en.FechaCreacion;
            com.Portada = juegoEN.Portada;
            com.Miembros = miembros;

            return com;
        }

        public IList<ComunidadViewModel> ConvertListENTModel(IList<ComunidadEN> ens)
        {
            IList<ComunidadViewModel> coms = new List<ComunidadViewModel>();

            foreach (ComunidadEN en in ens)
            {
                coms.Add(ConvertENToModelUI(en));
            }

            return coms;
        }
    }
}