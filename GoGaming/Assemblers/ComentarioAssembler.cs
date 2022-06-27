using GoGaming.Models;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class ComentarioAssembler
    {
        public ComentarioViewModel ConvertENToModelUI(ComentarioEN en)
        {
            ComentarioViewModel coment = new ComentarioViewModel();
            coment.Id = en.Id;
            coment.Contenido = en.Contenido;
            coment.Hora = (DateTime)en.Hora;
            return coment;
        }

        public IList<ComentarioViewModel> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<ComentarioViewModel> coments = new List<ComentarioViewModel>();
            foreach(ComentarioEN en in ens)
            {
                coments.Add(ConvertENToModelUI(en));
            }
            return coments;
        }
        
    }
}