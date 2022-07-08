using GoGaming.Controllers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class ComentarioAssembler : BasicController
    {
        public ComentarioViewModel ConvertENToModelUI(ComentarioEN en)
        {
            SessionInitialize();
            ComentarioCAD comentarioCAD = new ComentarioCAD(session);
            ComentarioCEN comentarioCEN = new ComentarioCEN(comentarioCAD);
            ComentarioViewModel coment = new ComentarioViewModel();

            coment.Id = en.Id;
            coment.Contenido = en.Contenido;
            coment.Hora = (DateTime)en.Hora;
            coment.Autor = en.Usuario.Id;
            coment.nameAutor = new UsuarioCEN().ReadOID(en.Usuario.Id).Nickname;
            coment.Post = en.Post.Id;
            coment.Hijos = comentarioCEN.GetHijosFromComentario(en.Id).Count;
            if (en.ComentarioPadre != null) coment.Padre = true;
            else coment.Padre = false;

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