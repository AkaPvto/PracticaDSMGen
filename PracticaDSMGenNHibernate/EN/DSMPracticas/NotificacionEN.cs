
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
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo post
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN Post {
        get { return post; } set { post = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, string texto, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post
                      )
{
        this.init (Id, texto, post);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Texto, notificacion.Post);
}

private void init (int id
                   , string texto, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post)
{
        this.Id = id;


        this.Texto = texto;

        this.Post = post;
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
