
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class NotificacionCP : BasicCP
{
public PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN New_ (int p_post)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Notificacion_new_) ENABLED START*/

        INotificacionCAD notificacionCAD = null;
        NotificacionCEN notificacionCEN = null;

        PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN result = null;


        try
        {
                SessionInitializeTransaction ();
                notificacionCAD = new NotificacionCAD (session);
                notificacionCEN = new  NotificacionCEN (notificacionCAD);




                int oid;
                //Initialized NotificacionEN
                NotificacionEN notificacionEN;
                notificacionEN = new NotificacionEN ();

                if (p_post != -1) {
                        notificacionEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                        notificacionEN.Post.Id = p_post;
                }

                //Call to NotificacionCAD

                oid = notificacionCAD.New_ (notificacionEN);
                result = notificacionCAD.ReadOIDDefault (oid);



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
