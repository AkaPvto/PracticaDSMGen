
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_interactPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class UsuarioCP : BasicCP
{
public bool InteractPost (int p_usuario, int p_post)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_interactPost) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IPostCAD postCAD = null;
        Boolean alreadyLiked = false;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                IList<PostEN> postLikedByUsuario = postCAD.GetPostLiked (p_usuario);
                PostEN postEN = postCAD.ReadOID (p_post);
                IList<UsuarioEN> userOfComunidad = usuarioCAD.GetComunidadUsu (postEN.Comunidad.Nombre);
                UsuarioEN usuarioEN = usuarioCAD.ReadOID (p_usuario);
                // Write here your custom transaction ...

                if (userOfComunidad.Contains (usuarioEN)) {
                        if (postLikedByUsuario.Contains (postEN)) alreadyLiked = true;
                        if (alreadyLiked) {
                                usuarioCEN.UsuarioUnlikePost (p_usuario, new List<int>(){
                                                p_post
                                        });
                                Console.WriteLine ("Se ha quitado el like del post " + p_post + "\n");
                                return true;
                        }
                        else{
                                usuarioCEN.UsuarioLikePost (p_usuario, new List<int>() {
                                                p_post
                                        });
                                Console.WriteLine ("Se le ha dado like al post: " + p_post + "\n");
                                return true;
                        }
                }
                Console.WriteLine ("Tienes que pertenecer a una comunidad para darle like a un post\n");
                return false;




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


        /*PROTECTED REGION END*/
}
}
}
