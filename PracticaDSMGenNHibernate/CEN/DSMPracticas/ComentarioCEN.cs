

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public void Modify (int p_Comentario_OID, string p_contenido, Nullable<DateTime> p_hora, int p_likes)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Contenido = p_contenido;
        comentarioEN.Hora = p_hora;
        comentarioEN.Likes = p_likes;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> GetComentariosFecha (int p_post)
{
        return _IComentarioCAD.GetComentariosFecha (p_post);
}
public void AddComentarioHijo (int p_Comentario_OID, System.Collections.Generic.IList<int> p_comentariosHijos_OIDs)
{
        //Call to ComentarioCAD

        _IComentarioCAD.AddComentarioHijo (p_Comentario_OID, p_comentariosHijos_OIDs);
}
public int NewRaiz (string p_contenido, int p_usuario, int p_post, Nullable<DateTime> p_hora, int p_likes)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Contenido = p_contenido;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                comentarioEN.Usuario = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                comentarioEN.Usuario.Id = p_usuario;
        }


        if (p_post != -1) {
                // El argumento p_post -> Property post es oid = false
                // Lista de oids id
                comentarioEN.Post = new PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN ();
                comentarioEN.Post.Id = p_post;
        }

        comentarioEN.Hora = p_hora;

        comentarioEN.Likes = p_likes;

        //Call to ComentarioCAD

        oid = _IComentarioCAD.NewRaiz (comentarioEN);
        return oid;
}
}
}
