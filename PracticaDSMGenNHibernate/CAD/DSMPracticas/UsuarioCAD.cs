
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
 * Clase Usuario:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (int id
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nickname = usuario.Nickname;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Telefono = usuario.Telefono;


                usuarioEN.Direccion = usuario.Direccion;


                usuarioEN.Foto = usuario.Foto;










                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Baneado = usuario.Baneado;


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void AddJuego (int p_Usuario_OID, System.Collections.Generic.IList<string> p_juego_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN juegoENAux = null;
                if (usuarioEN.Juego == null) {
                        usuarioEN.Juego = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN>();
                }

                foreach (string item in p_juego_OIDs) {
                        juegoENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN ();
                        juegoENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN), item);
                        juegoENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Juego.Add (juegoENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int New_ (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Id;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Id);

                usuarioEN.Nickname = usuario.Nickname;


                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Email = usuario.Email;


                usuarioEN.Telefono = usuario.Telefono;


                usuarioEN.Direccion = usuario.Direccion;


                usuarioEN.Foto = usuario.Foto;


                usuarioEN.Pass = usuario.Pass;


                usuarioEN.Baneado = usuario.Baneado;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
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
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), id);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (int id
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AddComunidad (int p_Usuario_OID, System.Collections.Generic.IList<string> p_comunidad_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadENAux = null;
                if (usuarioEN.Comunidad == null) {
                        usuarioEN.Comunidad = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN>();
                }

                foreach (string item in p_comunidad_OIDs) {
                        comunidadENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN ();
                        comunidadENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN), item);
                        comunidadENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Comunidad.Add (comunidadENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteComunidad (int p_Usuario_OID, System.Collections.Generic.IList<string> p_comunidad_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidadENAux = null;
                if (usuarioEN.Comunidad != null) {
                        foreach (string item in p_comunidad_OIDs) {
                                comunidadENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN), item);
                                if (usuarioEN.Comunidad.Contains (comunidadENAux) == true) {
                                        usuarioEN.Comunidad.Remove (comunidadENAux);
                                        comunidadENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comunidad_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddFollowing (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (usuarioEN.Usuario == null) {
                        usuarioEN.Usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
                }

                foreach (int item in p_usuario_OIDs) {
                        usuarioENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                        usuarioENAux.Usuario_0.Add (usuarioEN);

                        usuarioEN.Usuario.Add (usuarioENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteFollowing (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioENAux = null;
                if (usuarioEN.Usuario != null) {
                        foreach (int item in p_usuario_OIDs) {
                                usuarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), item);
                                if (usuarioEN.Usuario.Contains (usuarioENAux) == true) {
                                        usuarioEN.Usuario.Remove (usuarioENAux);
                                        usuarioENAux.Usuario_0.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_usuario_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetComunidadUsu (string p_comunidad)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT usuario FROM UsuarioEN as usuario INNER JOIN usuario.Comunidad as comunidad WHERE comunidad.Nombre = :p_comunidad";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENgetComunidadUsuHQL");
                query.SetParameter ("p_comunidad", p_comunidad);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetFollowed (int p_usuario)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where SELECT usuario FROM UsuarioEN as usuario INNER JOIN usuario.Usuario_0 as followed WHERE followed.Id = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENgetFollowedHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void UsuarioLikePost (int p_Usuario_OID, System.Collections.Generic.IList<int> p_postLiked_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postLikedENAux = null;
                if (usuarioEN.PostLiked == null) {
                        usuarioEN.PostLiked = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
                }

                foreach (int item in p_postLiked_OIDs) {
                        postLikedENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                        postLikedENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN), item);
                        postLikedENAux.UsuarioLiker.Add (usuarioEN);

                        usuarioEN.PostLiked.Add (postLikedENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UsuarioUnlikePost (int p_Usuario_OID, System.Collections.Generic.IList<int> p_postLiked_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postLikedENAux = null;
                if (usuarioEN.PostLiked != null) {
                        foreach (int item in p_postLiked_OIDs) {
                                postLikedENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN), item);
                                if (usuarioEN.PostLiked.Contains (postLikedENAux) == true) {
                                        usuarioEN.PostLiked.Remove (postLikedENAux);
                                        postLikedENAux.UsuarioLiker.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_postLiked_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
