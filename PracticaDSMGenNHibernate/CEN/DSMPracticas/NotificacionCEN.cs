

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

public void Modify (int p_Notificacion_OID, string p_texto, Nullable<DateTime> p_hora)
{
        NotificacionEN notificacionEN = null;

        //Initialized NotificacionEN
        notificacionEN = new NotificacionEN ();
        notificacionEN.Id = p_Notificacion_OID;
        notificacionEN.Texto = p_texto;
        notificacionEN.Hora = p_hora;
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
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> GetNotificacionesUsuario (int p_usuario)
{
        return _INotificacionCAD.GetNotificacionesUsuario (p_usuario);
}
public void AddUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to NotificacionCAD

        _INotificacionCAD.AddUsuarios (p_Notificacion_OID, p_usuario_OIDs);
}
public void DeleteUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to NotificacionCAD

        _INotificacionCAD.DeleteUsuarios (p_Notificacion_OID, p_usuario_OIDs);
}
}
}
