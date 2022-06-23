
using System;
using System.Text;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.Exceptions;


/*
 * Clase Notificacion:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class NotificacionCAD : BasicCAD, INotificacionCAD
{
public NotificacionCAD() : base ()
{
}

public NotificacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotificacionEN ReadOIDDefault (int id
                                      )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(NotificacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                        else
                                result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);



                notificacionEN.Texto = notificacion.Texto;


                notificacionEN.Hora = notificacion.Hora;

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (notificacion.Post != null) {
                        // Argumento OID y no colección.
                        notificacion.Post = (PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN), notificacion.Post.Id);

                        notificacion.Post.Notificacion
                        .Add (notificacion);
                }

                session.Save (notificacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacion.Id;
}

public void Modify (NotificacionEN notificacion)
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), notificacion.Id);

                notificacionEN.Texto = notificacion.Texto;


                notificacionEN.Hora = notificacion.Hora;

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                NotificacionEN notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), id);
                session.Delete (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: NotificacionEN
public NotificacionEN ReadOID (int id
                               )
{
        NotificacionEN notificacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Get (typeof(NotificacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notificacionEN;
}

public System.Collections.Generic.IList<NotificacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotificacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotificacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotificacionEN>();
                else
                        result = session.CreateCriteria (typeof(NotificacionEN)).List<NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> GetNotificacionesUsuario (int p_usuario)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM NotificacionEN self where SELECT notificacion FROM NotificacionEN as notificacion INNER JOIN notificacion.Usuario as usuario WHERE usuario.Id = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("NotificacionENgetNotificacionesUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN notificacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (notificacionEN.Usuario == null) {
                        notificacionEN.Usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
                }

                foreach (int item in p_usuario_OIDs) {
                        usuarioENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                        usuarioENAux.Notificacion.Add (notificacionEN);

                        notificacionEN.Usuario.Add (usuarioENAux);
                }


                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteUsuarios (int p_Notificacion_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN notificacionEN = null;
                notificacionEN = (NotificacionEN)session.Load (typeof(NotificacionEN), p_Notificacion_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (notificacionEN.Usuario != null) {
                        foreach (int item in p_usuario_OIDs) {
                                usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                                if (notificacionEN.Usuario.Contains (usuarioENAux) == true) {
                                        notificacionEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Notificacion.Remove (notificacionEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in NotificacionEN");
                        }
                }

                session.Update (notificacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in NotificacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
