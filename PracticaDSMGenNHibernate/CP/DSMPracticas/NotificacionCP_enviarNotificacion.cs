
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net;
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class NotificacionCP : BasicCP
{
public void EnviarNotificacion (int p_oid)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/

        INotificacionCAD notificacionCAD = null;
        NotificacionCEN notificacionCEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionCAD = new NotificacionCAD (session);
                notificacionCEN = new  NotificacionCEN (notificacionCAD);

                // Write here your custom transaction ...
                NotificacionEN notificacion = notificacionCAD.ReadOIDDefault(p_oid);

                UsuarioCAD usuarioCAD = new UsuarioCAD();
                IList<UsuarioEN> usuarios = usuarioCAD.GetComunidadUsu(notificacion.Post.Comunidad.Nombre);


                //Preparamos el correo   
                var fromAddress = new MailAddress("gogaminggroupsl@gmail.com", "Go Gaming");

                const string fromPassword = "qamecfuphnkrpmxr";
                string subject = "Novedades en la comunidad de " + notificacion.Post.Comunidad.Nombre;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                for (int i = 0; i < usuarios.Count; i++)
                {
                    UsuarioEN usuario = usuarios[i];
                    var toAddress = new MailAddress(usuario.Email, usuario.Nombre);
                    var msg = "¡Hola, " + usuario.Nickname + "! " + notificacion.Texto;

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = msg
                    })
                    {
                        smtp.Send(message);
                    }
                }



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
