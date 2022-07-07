
using System;
// Definición clase UsuarioEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class UsuarioEN
{
/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo juego
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego;



/**
 *	Atributo comunidad
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN> comunidad;



/**
 *	Atributo post
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario;



/**
 *	Atributo usuario_0
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario_0;



/**
 *	Atributo aviso
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> aviso;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo baneado
 */
private bool baneado;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo postLiked
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> postLiked;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion;



/**
 *	Atributo admin
 */
private bool admin;






public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Juego {
        get { return juego; } set { juego = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN> Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> Post {
        get { return post; } set { post = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> Usuario_0 {
        get { return usuario_0; } set { usuario_0 = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> Aviso {
        get { return aviso; } set { aviso = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> PostLiked {
        get { return postLiked; } set { postLiked = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual bool Admin {
        get { return admin; } set { admin = value;  }
}





public UsuarioEN()
{
        juego = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN>();
        comunidad = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN>();
        post = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
        comentario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN>();
        usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
        usuario_0 = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
        aviso = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN>();
        postLiked = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN>();
        notificacion = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN>();
}



public UsuarioEN(int id, string nickname, string nombre, string apellidos, string email, int telefono, string direccion, string foto, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN> comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario_0, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> aviso, String pass, bool baneado, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> postLiked, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, bool admin
                 )
{
        this.init (Id, nickname, nombre, apellidos, email, telefono, direccion, foto, juego, comunidad, post, comentario, usuario, usuario_0, aviso, pass, baneado, postLiked, notificacion, admin);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Nickname, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.Telefono, usuario.Direccion, usuario.Foto, usuario.Juego, usuario.Comunidad, usuario.Post, usuario.Comentario, usuario.Usuario, usuario.Usuario_0, usuario.Aviso, usuario.Pass, usuario.Baneado, usuario.PostLiked, usuario.Notificacion, usuario.Admin);
}

private void init (int id
                   , string nickname, string nombre, string apellidos, string email, int telefono, string direccion, string foto, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN> comunidad, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario_0, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> aviso, String pass, bool baneado, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> postLiked, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.NotificacionEN> notificacion, bool admin)
{
        this.Id = id;


        this.Nickname = nickname;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;

        this.Telefono = telefono;

        this.Direccion = direccion;

        this.Foto = foto;

        this.Juego = juego;

        this.Comunidad = comunidad;

        this.Post = post;

        this.Comentario = comentario;

        this.Usuario = usuario;

        this.Usuario_0 = usuario_0;

        this.Aviso = aviso;

        this.Pass = pass;

        this.Baneado = baneado;

        this.PostLiked = postLiked;

        this.Notificacion = notificacion;

        this.Admin = admin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
