
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
 *	Atributo usuarioCreador
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioCreador;



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



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo hora
 */
private Nullable<DateTime> hora;



/**
 *	Atributo likes
 */
private int likes;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN UsuarioCreador {
        get { return usuarioCreador; } set { usuarioCreador = value;  }
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



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual Nullable<DateTime> Hora {
        get { return hora; } set { hora = value;  }
}



public virtual int Likes {
        get { return likes; } set { likes = value;  }
}





public PostEN()
{
        comentario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN>();
        notificacion = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN>();
}



public PostEN(int id, string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioCreador, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum categoria, string titulo, string imagen, Nullable<DateTime> hora, int likes
              )
{
        this.init (Id, contenido, usuarioCreador, comunidad, comentario, notificacion, categoria, titulo, imagen, hora, likes);
}


public PostEN(PostEN post)
{
        this.init (Id, post.Contenido, post.UsuarioCreador, post.Comunidad, post.Comentario, post.Notificacion, post.Categoria, post.Titulo, post.Imagen, post.Hora, post.Likes);
}

private void init (int id
                   , string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuarioCreador, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum categoria, string titulo, string imagen, Nullable<DateTime> hora, int likes)
{
        this.Id = id;


        this.Contenido = contenido;

        this.UsuarioCreador = usuarioCreador;

        this.Comunidad = comunidad;

        this.Comentario = comentario;

        this.Notificacion = notificacion;

        this.Categoria = categoria;

        this.Titulo = titulo;

        this.Imagen = imagen;

        this.Hora = hora;

        this.Likes = likes;
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
