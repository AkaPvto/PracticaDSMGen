
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
 * Clase Comunidad:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class ComunidadCAD : BasicCAD, IComunidadCAD
{
public ComunidadCAD() : base ()
{
}

public ComunidadCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComunidadEN ReadOIDDefault (string nombre
                                   )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComunidadEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                        else
                                result = session.CreateCriteria (typeof(ComunidadEN)).List<ComunidadEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadEN comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), comunidad.Nombre);

                comunidadEN.CodigoComunidad = comunidad.CodigoComunidad;


                comunidadEN.Descripcion = comunidad.Descripcion;


                comunidadEN.FechaCreacion = comunidad.FechaCreacion;




                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void DeletePost (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadEN = null;
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), p_Comunidad_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postENAux = null;
                if (comunidadEN.Post != null) {
                        foreach (int item in p_post_OIDs) {
                                postENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN), item);
                                if (comunidadEN.Post.Contains (postENAux) == true) {
                                        comunidadEN.Post.Remove (postENAux);
                                        postENAux.Comunidad = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_post_OIDs you are trying to unrelationer, doesn't exist in ComunidadEN");
                        }
                }

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public string New_ (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                if (comunidad.Juego != null) {
                        // Argumento OID y no colección.
                        comunidad.Juego = (PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN), comunidad.Juego.Nombre);

                        comunidad.Juego.Comunidad
                                = comunidad;
                }

                session.Save (comunidad);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidad.Nombre;
}

public void Modify (ComunidadEN comunidad)
{
        try
        {
                SessionInitializeTransaction ();
                ComunidadEN comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), comunidad.Nombre);

                comunidadEN.CodigoComunidad = comunidad.CodigoComunidad;


                comunidadEN.Descripcion = comunidad.Descripcion;


                comunidadEN.FechaCreacion = comunidad.FechaCreacion;

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
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
                ComunidadEN comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), nombre);
                session.Delete (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComunidadEN
public ComunidadEN ReadOID (string nombre
                            )
{
        ComunidadEN comunidadEN = null;

        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Get (typeof(ComunidadEN), nombre);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComunidadEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComunidadEN>();
                else
                        result = session.CreateCriteria (typeof(ComunidadEN)).List<ComunidadEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AddUsuarios (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadEN = null;
        try
        {
                SessionInitializeTransaction ();
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), p_Comunidad_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario == null) {
                        comunidadEN.Usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
                }

                foreach (int item in p_usuario_OIDs) {
                        usuarioENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                        usuarioENAux.Comunidad.Add (comunidadEN);

                        comunidadEN.Usuario.Add (usuarioENAux);
                }


                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteUsuarios (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadEN = null;
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), p_Comunidad_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (comunidadEN.Usuario != null) {
                        foreach (int item in p_usuario_OIDs) {
                                usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                                if (comunidadEN.Usuario.Contains (usuarioENAux) == true) {
                                        comunidadEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Comunidad.Remove (comunidadEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in ComunidadEN");
                        }
                }

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddPost (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadEN = null;
                comunidadEN = (ComunidadEN)session.Load (typeof(ComunidadEN), p_Comunidad_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postENAux = null;
                if (comunidadEN.Post != null) {
                        foreach (int item in p_post_OIDs) {
                                postENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN), item);
                                if (comunidadEN.Post.Contains (postENAux) == true) {
                                        comunidadEN.Post.Remove (postENAux);
                                        postENAux.Comunidad = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_post_OIDs you are trying to unrelationer, doesn't exist in ComunidadEN");
                        }
                }

                session.Update (comunidadEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in ComunidadCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
