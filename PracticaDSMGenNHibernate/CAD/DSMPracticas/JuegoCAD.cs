
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
 * Clase Juego:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class JuegoCAD : BasicCAD, IJuegoCAD
{
public JuegoCAD() : base ()
{
}

public JuegoCAD(ISession sessionAux) : base (sessionAux)
{
}



public JuegoEN ReadOIDDefault (string nombre
                               )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(JuegoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<JuegoEN>();
                        else
                                result = session.CreateCriteria (typeof(JuegoEN)).List<JuegoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Nombre);

                juegoEN.Descripcion = juego.Descripcion;




                juegoEN.Portada = juego.Portada;


                session.Update (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                if (juego.Genero != null) {
                        for (int i = 0; i < juego.Genero.Count; i++) {
                                juego.Genero [i] = (PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN), juego.Genero [i].Nombre);
                                juego.Genero [i].Juego.Add (juego);
                        }
                }

                session.Save (juego);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juego.Nombre;
}

public void Modify (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Nombre);

                juegoEN.Descripcion = juego.Descripcion;


                juegoEN.Portada = juego.Portada;

                session.Update (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string nombre
                     )
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), nombre);
                session.Delete (juegoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: JuegoEN
public JuegoEN ReadOID (string nombre
                        )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(JuegoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<JuegoEN>();
                else
                        result = session.CreateCriteria (typeof(JuegoEN)).List<JuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string nombre)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM JuegoEN self where FROM JuegoEN as juego WHERE juego.Nombre like CONCAT('%', :p_nombre, '%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("JuegoENbusquedaHQL");
                query.SetParameter ("nombre", nombre);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> GetJuegosPorUsuario (int p_usuario)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM JuegoEN self where SELECT juego FROM JuegoEN as juego INNER JOIN juego.Usuario as usu WHERE usu.Id = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("JuegoENgetJuegosPorUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in JuegoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
