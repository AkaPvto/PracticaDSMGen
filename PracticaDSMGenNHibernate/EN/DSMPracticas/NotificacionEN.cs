
using System;
// Definición clase NotificacionEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class NotificacionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo post
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario;



/**
 *	Atributo texto
 */
private string texto;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN Post {
        get { return post; } set { post = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}





public NotificacionEN()
{
        usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
}



public NotificacionEN(int id, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, string texto
                      )
{
        this.init (Id, post, usuario, texto);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Post, notificacion.Usuario, notificacion.Texto);
}

private void init (int id
                   , PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, string texto)
{
        this.Id = id;


        this.Post = post;

        this.Usuario = usuario;

        this.Texto = texto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
