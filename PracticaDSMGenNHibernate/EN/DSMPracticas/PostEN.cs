
using System;
// Definición clase PostEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class PostEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo usuario
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario;



/**
 *	Atributo comunidad
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion;



/**
 *	Atributo categoria
 */
private PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum categoria;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}





public PostEN()
{
        comentario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN>();
        notificacion = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN>();
}



public PostEN(int id, string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum categoria
              )
{
        this.init (Id, contenido, usuario, comunidad, comentario, notificacion, categoria);
}


public PostEN(PostEN post)
{
        this.init (Id, post.Contenido, post.Usuario, post.Comunidad, post.Comentario, post.Notificacion, post.Categoria);
}

private void init (int id
                   , string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum categoria)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Usuario = usuario;

        this.Comunidad = comunidad;

        this.Comentario = comentario;

        this.Notificacion = notificacion;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PostEN t = obj as PostEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
