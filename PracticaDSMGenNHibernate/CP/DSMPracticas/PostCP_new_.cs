
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Post_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class PostCP : BasicCP
{
public PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN New_ (string p_contenido, int p_usuarioCreador, int p_comunidad, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum p_categoria, string p_titulo, string p_imagen, Nullable<DateTime> p_hora)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Post_new_) ENABLED START*/

        IPostCAD postCAD = null;
        PostCEN postCEN = null;

        PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN result = null;


        try
        {
                SessionInitializeTransaction ();
                postCAD = new PostCAD (session);
                postCEN = new  PostCEN (postCAD);




                int oid;

                //Initialized NotificacionCP
                NotificacionCP notificacionCP = new NotificacionCP ();

                //Initialized PostEN
                PostEN postEN;
                postEN = new PostEN ();
                postEN.Contenido = p_contenido;


                if (p_usuarioCreador != -1) {
                        postEN.UsuarioCreador = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        postEN.UsuarioCreador.Id = p_usuarioCreador;
                }


                if (p_comunidad != -1) {
                        postEN.Comunidad = new PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN ();
                        postEN.Comunidad.Id = p_comunidad;
                }

                postEN.Categoria = p_categoria;

                postEN.Titulo = p_titulo;

                postEN.Imagen = p_imagen;

                postEN.Hora = p_hora;

                postEN.Likes = 0;

                //Call to PostCAD

                oid = postCAD.New_ (postEN);
                result = postCAD.ReadOIDDefault (oid);

                //notificacionCP.New_ (oid);

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
