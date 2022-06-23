
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
        Boolean interaction = false;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                postCAD = new PostCAD (session);
                IList<PostEN> postLikedByUsuario = postCAD.GetPostLiked (p_usuario);
                PostEN postEN = postCAD.ReadOID (p_post);
                IList<UsuarioEN> userOfComunidad = usuarioCAD.GetUsuariosComunidad (postEN.Comunidad.Nombre);
                UsuarioEN usuarioEN = usuarioCAD.ReadOID (p_usuario);
                // Write here your custom transaction ...

                if (userOfComunidad.Contains (usuarioEN)) {
                        interaction = true;
                        if (postLikedByUsuario.Contains (postEN)) {
                                usuarioCEN.UsuarioUnlikePost (p_usuario, new List<int>(){
                                                p_post
                                        });
                                postEN.Likes = -1;
                                postCAD.Modify (postEN);
                                Console.WriteLine ("Se ha quitado el like del post " + p_post);
                        }
                        else {
                                usuarioCEN.UsuarioLikePost (p_usuario, new List<int>() {
                                                p_post
                                        });
                                postEN.Likes = -1;
                                postCAD.Modify (postEN);
                                Console.WriteLine ("Se le ha dado like al post: " + p_post);
                        }
                }
                else Console.WriteLine ("Tienes que pertenecer a una comunidad para darle like a un post");




                SessionCommit ();
                return interaction;
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
