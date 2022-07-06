
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



public JuegoEN ReadOIDDefault (int id
                               )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), id);
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
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Id);

                juegoEN.Nombre = juego.Nombre;


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


public int New_ (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                if (juego.Genero != null) {
                        for (int i = 0; i < juego.Genero.Count; i++) {
                                juego.Genero [i] = (PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN), juego.Genero [i].Id);
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

        return juego.Id;
}

public void Modify (JuegoEN juego)
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), juego.Id);

                juegoEN.Nombre = juego.Nombre;


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
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                JuegoEN juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), id);
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
public JuegoEN ReadOID (int id
                        )
{
        JuegoEN juegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Get (typeof(JuegoEN), id);
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

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string p_nombre)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM JuegoEN self where FROM JuegoEN as juego WHERE juego.Nombre like CONCAT('%', :p_nombre, '%')";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("JuegoENbusquedaHQL");
                query.SetParameter ("p_nombre", p_nombre);

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
public void AddGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juegoEN = null;
        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), p_Juego_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN generoENAux = null;
                if (juegoEN.Genero == null) {
                        juegoEN.Genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
                }

                foreach (int item in p_genero_OIDs) {
                        generoENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN ();
                        generoENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN), item);
                        generoENAux.Juego.Add (juegoEN);

                        juegoEN.Genero.Add (generoENAux);
                }


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

public void DeleteGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juegoEN = null;
                juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), p_Juego_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN generoENAux = null;
                if (juegoEN.Genero != null) {
                        foreach (int item in p_genero_OIDs) {
                                generoENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN), item);
                                if (juegoEN.Genero.Contains (generoENAux) == true) {
                                        juegoEN.Genero.Remove (generoENAux);
                                        generoENAux.Juego.Remove (juegoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_genero_OIDs you are trying to unrelationer, doesn't exist in JuegoEN");
                        }
                }

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
public void AddComunidad (int p_Juego_OID, int p_comunidad_OID)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juegoEN = null;
        try
        {
                SessionInitializeTransaction ();
                juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), p_Juego_OID);
                juegoEN.Comunidad = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN), p_comunidad_OID);

                juegoEN.Comunidad.Juego = juegoEN;




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

public void DeleteComunidad (int p_Juego_OID, int p_comunidad_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juegoEN = null;
                juegoEN = (JuegoEN)session.Load (typeof(JuegoEN), p_Juego_OID);

                if (juegoEN.Comunidad.Id == p_comunidad_OID) {
                        juegoEN.Comunidad = null;
                        PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadEN = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN), p_comunidad_OID);
                        comunidadEN.Juego = null;
                }
                else
                        throw new ModelException ("The identifier " + p_comunidad_OID + " in p_comunidad_OID you are trying to unrelationer, doesn't exist in JuegoEN");

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
}
}
