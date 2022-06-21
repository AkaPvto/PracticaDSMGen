
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/
using System.Net.Mail;
using System.Net;

/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class NotificacionCEN
{
public void EnviarNotificacion (int p_oid)
{
            /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/

            // Write here your custom code...
            //Recuperamos los datos que vamos que necesitar del usuario
            UsuarioCAD usuarioCAD = new UsuarioCAD();
            UsuarioEN usuario = usuarioCAD.ReadOIDDefault(p_oid);
                          
            //Preparamos y mandamos el correo    
            var fromAddress = new MailAddress("gogaminggroupsl@gmail.com", "Go Gaming");
            var toAddress = new MailAddress(usuario.Email, "To Name");
            const string fromPassword = "qamecfuphnkrpmxr";
            const string subject = "Novedades en la comunidad de *Insertar Comunidad*";
            const string body = "¡Hola, *Insertar nombre*! El usuario *Insertar nombre* ha subido un nuevo post a la comunidad de *Insertar Comunidad*. ¡No te lo pierdas!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            /*PROTECTED REGION END*/
        }
}
}
