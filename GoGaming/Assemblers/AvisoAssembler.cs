using GoGaming.Models;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class AvisoAssembler
    {
        public AvisoViewModel ConvertENToModelUI(AvisoEN en)
        {
            AvisoViewModel aviso = new AvisoViewModel();
            aviso.Id = en.Id;
            aviso.Texto = en.Texto;
            aviso.Hora = (DateTime)en.Hora;
            return aviso;
        }

        public IList<AvisoViewModel> ConvertListENToModel(IList<AvisoEN> ens)
        {
            IList<AvisoViewModel> avisos = new List<AvisoViewModel>();
            foreach(AvisoEN en in ens)
            {
                avisos.Add(ConvertENToModelUI(en));
            }
            return avisos;
        }
        
    }
}