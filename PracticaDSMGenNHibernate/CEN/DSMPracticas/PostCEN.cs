

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
 *      Definition of the class PostCEN
 *
 */
public partial class PostCEN
{
private IPostCAD _IPostCAD;

public PostCEN()
{
        this._IPostCAD = new PostCAD ();
}

public PostCEN(IPostCAD _IPostCAD)
{
        this._IPostCAD = _IPostCAD;
}

public IPostCAD get_IPostCAD ()
{
        return this._IPostCAD;
}

public void AddComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to PostCAD

        _IPostCAD.AddComentario (p_Post_OID, p_comentario_OIDs);
}
public void BorrarComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs)
{
        //Call to PostCAD

        _IPostCAD.BorrarComentario (p_Post_OID, p_comentario_OIDs);
}
public int New_ (string p_contenido, int p_usuario, string p_comunidad, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum p_categoria, string p_titulo, string p_imagen, Nullable<DateTime> p_fecha, Nullable<DateTime> p_hora, int p_likes)
{
        PostEN postEN = null;
        int oid;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Contenido = p_contenido;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                postEN.Usuario = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                postEN.Usuario.Id = p_usuario;
        }


        if (p_comunidad != null) {
                // El argumento p_comunidad -> Property comunidad es oid = false
                // Lista de oids id
                postEN.Comunidad = new PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN ();
                postEN.Comunidad.Nombre = p_comunidad;
        }

        postEN.Categoria = p_categoria;

        postEN.Titulo = p_titulo;

        postEN.Imagen = p_imagen;

        postEN.Fecha = p_fecha;

        postEN.Hora = p_hora;

        postEN.Likes = p_likes;

        //Call to PostCAD

        oid = _IPostCAD.New_ (postEN);
        return oid;
}

public void Modify (int p_Post_OID, string p_contenido, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum p_categoria, string p_titulo, string p_imagen, Nullable<DateTime> p_fecha, Nullable<DateTime> p_hora, int p_likes)
{
        PostEN postEN = null;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Id = p_Post_OID;
        postEN.Contenido = p_contenido;
        postEN.Categoria = p_categoria;
        postEN.Titulo = p_titulo;
        postEN.Imagen = p_imagen;
        postEN.Fecha = p_fecha;
        postEN.Hora = p_hora;
        postEN.Likes = p_likes;
        //Call to PostCAD

        _IPostCAD.Modify (postEN);
}

public void Destroy (int id
                     )
{
        _IPostCAD.Destroy (id);
}

public PostEN ReadOID (int id
                       )
{
        PostEN postEN = null;

        postEN = _IPostCAD.ReadOID (id);
        return postEN;
}

public System.Collections.Generic.IList<PostEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PostEN> list = null;

        list = _IPostCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostsUsu (int ? p_usu)
{
        return _IPostCAD.GetPostsUsu (p_usu);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostPorCategoria (PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum ? p_categoria)
{
        return _IPostCAD.GetPostPorCategoria (p_categoria);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostComunidadLikes (string p_comunidad)
{
        return _IPostCAD.GetPostComunidadLikes (p_comunidad);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostComunidadFecha (string p_comunidad)
{
        return _IPostCAD.GetPostComunidadFecha (p_comunidad);
}
}
}
