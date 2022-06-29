using GoGaming.Models;
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

            com.CodigoComunidad = en.Id;
            com.Nombre = en.Nombre;

            com.Juego = en.Juego.Id;

            com.Descripcion = en.Descripcion;
            com.FechaCreacion = (DateTime)en.FechaCreacion;

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