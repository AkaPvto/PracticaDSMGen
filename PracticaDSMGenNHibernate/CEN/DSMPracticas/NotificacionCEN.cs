

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;

using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
/*
 *      Definition of the class NotificacionCEN
 *
 */
public partial class NotificacionCEN
{
private INotificacionCAD _INotificacionCAD;

public NotificacionCEN()
{
        this._INotificacionCAD = new NotificacionCAD ();
}

public NotificacionCEN(INotificacionCAD _INotificacionCAD)
{
        this._INotificacionCAD = _INotificacionCAD;
}

public INotificacionCAD get_INotificacionCAD ()
{
        return this._INotificacionCAD;
}

public int New_ (string p_texto, int p_post)
{
        NotificacionEN notificacionEN = null;
        int oid;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Texto = p_texto;


        if (p_post != -1) {
                // El argumento p_post -> Property post es oid = false
                // Lista de oids id
                notificacionEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                notificacionEN.Post.Id = p_post;
        }

        //Call to NotificacionCAD

        oid = _INotificacionCAD.New_ (notificacionEN);
        return oid;
}

public void Modify (int p_Notificacion_OID, string p_texto)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Texto = p_texto;
        //Call to NotificacionCAD

        _INotificacionCAD.Modify (notificacionEN);
}

public void Destroy (int id
                     )
{
        _INotificacionCAD.Destroy (id);
}

public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        notificacionEN = _INotificacionCAD.ReadOID (id);
        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> list = null;

        list = _INotificacionCAD.ReadAll (first, size);
        return list;
}
}
}
