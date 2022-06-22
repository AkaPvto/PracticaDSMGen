
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






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN Post {
        get { return post; } set { post = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post
                      )
{
        this.init (Id, post);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (Id, notificacion.Post);
}

private void init (int id
                   , PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post)
{
        this.Id = id;


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
