using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using GoGaming.Models;

namespace GoGaming.Assemblers
{
    public class AvisoAssembler
    {
        public AvisoViewModel ConvertENToModelUI(AvisoEN en)
        {
            AvisoViewModel av = new AvisoViewModel();
            av.Id = en.Id;
            av.Texto = en.Texto;
            //esto sigue funcionando asi con el email?
            av.Usuario = en.Usuario.Email;
            av.Hora = (DateTime)en.Hora;

            return av;
        }

        public IList<AvisoViewModel> ConvertListENToModel(IList<AvisoEN> ens)
        {
            IList<AvisoViewModel> avs = new List<AvisoViewModel>();
            foreach (AvisoEN en in ens)
            {
                avs.Add(ConvertENToModelUI(en));
            }
            return avs;
        }
    }
}