
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
using System.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class NotificacionCEN
{
public void EnviarNotificacion (int p_oid)
{
            /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Notificacion_enviarNotificacion) ENABLED START*/

            // Write here your custom code...
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("gogaminggroupsl@gmail.com", "GoGaming", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add("smg163@gcloud.ua.es"); //Correo destino?
            correo.Subject = "Correo de prueba"; //Asunto
            correo.Body = "Este es un correo de prueba desde c#"; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("gogaminggroupsl@gmail.com", "ggPassword");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            smtp.Send(correo);
            /*PROTECTED REGION END*/
        }
}
}
