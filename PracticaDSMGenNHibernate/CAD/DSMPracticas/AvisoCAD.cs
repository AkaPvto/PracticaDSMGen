
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
 * Clase Aviso:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class AvisoCAD : BasicCAD, IAvisoCAD
{
public AvisoCAD() : base ()
{
}

public AvisoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AvisoEN ReadOIDDefault (int id
                               )
{
        AvisoEN avisoEN = null;

        try
        {
                SessionInitializeTransaction ();
                avisoEN = (AvisoEN)session.Get (typeof(AvisoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return avisoEN;
}

public System.Collections.Generic.IList<AvisoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AvisoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AvisoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AvisoEN>();
                        else
                                result = session.CreateCriteria (typeof(AvisoEN)).List<AvisoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AvisoEN aviso)
{
        try
        {
                SessionInitializeTransaction ();
                AvisoEN avisoEN = (AvisoEN)session.Load (typeof(AvisoEN), aviso.Id);

                avisoEN.Texto = aviso.Texto;



                avisoEN.Fecha = aviso.Fecha;


                avisoEN.Hora = aviso.Hora;

                session.Update (avisoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AvisoEN aviso)
{
        try
        {
                SessionInitializeTransaction ();
                if (aviso.Usuario != null) {
                        // Argumento OID y no colección.
                        aviso.Usuario = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), aviso.Usuario.Id);

                        aviso.Usuario.Aviso
                        .Add (aviso);
                }

                session.Save (aviso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return aviso.Id;
}

public void Modify (AvisoEN aviso)
{
        try
        {
                SessionInitializeTransaction ();
                AvisoEN avisoEN = (AvisoEN)session.Load (typeof(AvisoEN), aviso.Id);

                avisoEN.Texto = aviso.Texto;


                avisoEN.Fecha = aviso.Fecha;


                avisoEN.Hora = aviso.Hora;

                session.Update (avisoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
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
                AvisoEN avisoEN = (AvisoEN)session.Load (typeof(AvisoEN), id);
                session.Delete (avisoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AvisoEN
public AvisoEN ReadOID (int id
                        )
{
        AvisoEN avisoEN = null;

        try
        {
                SessionInitializeTransaction ();
                avisoEN = (AvisoEN)session.Get (typeof(AvisoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return avisoEN;
}

public System.Collections.Generic.IList<AvisoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AvisoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AvisoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AvisoEN>();
                else
                        result = session.CreateCriteria (typeof(AvisoEN)).List<AvisoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> GetAvisosUsu (int ? p_usu)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AvisoEN self where FROM AvisoEN as aviso WHERE aviso.Usuario.Id = :p_usu";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AvisoENgetAvisosUsuHQL");
                query.SetParameter ("p_usu", p_usu);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in AvisoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
