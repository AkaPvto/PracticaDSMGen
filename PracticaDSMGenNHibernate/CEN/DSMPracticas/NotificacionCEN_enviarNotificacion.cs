
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
        public void EnviarNotificacion(int p_oid)
        {
            /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/

            // Write here your custom code...
            //Recuperamos los datos que vamos a necesitar
            NotificacionCAD notificacionCAD = new NotificacionCAD();
            NotificacionEN notificacion = notificacionCAD.ReadOIDDefault(p_oid);

            UsuarioCAD usuarioCAD = new UsuarioCAD();
            IList<UsuarioEN> usuarios = usuarioCAD.GetComunidadUsu(notificacion.Post.Comunidad.Nombre);


            //Preparamos el correo   
            var fromAddress = new MailAddress("gogaminggroupsl@gmail.com", "Go Gaming");

            const string fromPassword = "qamecfuphnkrpmxr";
            string subject = "Novedades en la comunidad de" + notificacion.Post.Comunidad.Nombre;
            string body = "El usuario "+ notificacion.Post.UsuarioCreador.Nickname + " ha subido un nuevo post a la comunidad de " + notificacion.Post.Comunidad.Nombre + ". ¡No te lo pierdas!";

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
                var toAddress = new MailAddress(usuario.Email, "To Name");
                var msg = "¡Hola, " + usuario.Nickname + "!" + body;
            
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = msg
                })
                {
                    smtp.Send(message);
                }
            }
            /*PROTECTED REGION END*/
        }
}
}
