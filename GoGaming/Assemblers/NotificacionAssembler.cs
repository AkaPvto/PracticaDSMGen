using GoGaming.Models;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class NotificacionAssembler
    {
        public NotificacionViewModel ConvertENToModelUI(NotificacionEN en)
        {
            NotificacionViewModel not = new NotificacionViewModel();
            not.Id = en.Id;
            not.Texto = en.Texto;
            not.Hora = (DateTime)en.Hora;
            return not;
        }

        public IList<NotificacionViewModel> ConvertListENToModel(IList<NotificacionEN> ens)
        {
            IList<NotificacionViewModel> nots = new List<NotificacionViewModel>();
            foreach(NotificacionEN en in ens)
            {
                nots.Add(ConvertENToModelUI(en));
            }
            return nots;
        }
        
    }
}