
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Comentario_newRaiz) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class ComentarioCEN
{
public int NewRaiz (string p_contenido, int p_usuario, int p_post, Nullable<DateTime> p_hora)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Comentario_newRaiz_customized) START*/

        ComentarioEN comentarioEN = null;

        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Contenido = p_contenido;


        if (p_usuario != -1) {
                comentarioEN.Usuario = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                comentarioEN.Usuario.Id = p_usuario;
        }


        if (p_post != -1) {
                comentarioEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                comentarioEN.Post.Id = p_post;
        }

        comentarioEN.Hora = p_hora;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.NewRaiz (comentarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
