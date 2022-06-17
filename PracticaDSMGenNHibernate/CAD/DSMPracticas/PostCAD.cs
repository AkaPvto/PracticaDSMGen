
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
 * Clase Post:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class PostCAD : BasicCAD, IPostCAD
{
public PostCAD() : base ()
{
}

public PostCAD(ISession sessionAux) : base (sessionAux)
{
}



public PostEN ReadOIDDefault (int id
                              )
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}

public System.Collections.Generic.IList<PostEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PostEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PostEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PostEN>();
                        else
                                result = session.CreateCriteria (typeof(PostEN)).List<PostEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), post.Id);

                postEN.Contenido = post.Contenido;






                postEN.Categoria = post.Categoria;

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void AddComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postEN = null;
        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);
                PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN comentarioENAux = null;
                if (postEN.Comentario == null) {
                        postEN.Comentario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN>();
                }

                foreach (int item in p_comentario_OIDs) {
                        comentarioENAux = new PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN ();
                        comentarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN), item);
                        comentarioENAux.Post = postEN;

                        postEN.Comentario.Add (comentarioENAux);
                }


                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void BorrarComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN postEN = null;
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);

                PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN comentarioENAux = null;
                if (postEN.Comentario != null) {
                        foreach (int item in p_comentario_OIDs) {
                                comentarioENAux = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN), item);
                                if (postEN.Comentario.Contains (comentarioENAux) == true) {
                                        postEN.Comentario.Remove (comentarioENAux);
                                        comentarioENAux.Post = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comentario_OIDs you are trying to unrelationer, doesn't exist in PostEN");
                        }
                }

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int New_ (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                if (post.Usuario != null) {
                        // Argumento OID y no colección.
                        post.Usuario = (PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN), post.Usuario.Id);

                        post.Usuario.Post
                        .Add (post);
                }
                if (post.Comunidad != null) {
                        // Argumento OID y no colección.
                        post.Comunidad = (PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN)session.Load (typeof(PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN), post.Comunidad.Nombre);

                        post.Comunidad.Post
                        .Add (post);
                }

                session.Save (post);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return post.Id;
}

public void Modify (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), post.Id);

                postEN.Contenido = post.Contenido;


                postEN.Categoria = post.Categoria;

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
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
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), id);
                session.Delete (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PostEN
public PostEN ReadOID (int id
                       )
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}

public System.Collections.Generic.IList<PostEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PostEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PostEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PostEN>();
                else
                        result = session.CreateCriteria (typeof(PostEN)).List<PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostsUsu (int ? p_usu)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PostEN self where FROM PostEN as post WHERE post.Usuario.Id = :usu";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PostENgetPostsUsuHQL");
                query.SetParameter ("p_usu", p_usu);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostPorCategoria (PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum ? p_categoria)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PostEN self where FROM PostEN as post WHERE post.Categoria = :categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PostENgetPostPorCategoriaHQL");
                query.SetParameter ("p_categoria", p_categoria);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
