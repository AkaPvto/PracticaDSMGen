
using System;
// Definición clase ComentarioEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class ComentarioEN
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
 *	Atributo post
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post;



/**
 *	Atributo comentariosHijos
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentariosHijos;



/**
 *	Atributo comentarioPadre
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN comentarioPadre;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN Post {
        get { return post; } set { post = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> ComentariosHijos {
        get { return comentariosHijos; } set { comentariosHijos = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN ComentarioPadre {
        get { return comentarioPadre; } set { comentarioPadre = value;  }
}





public ComentarioEN()
{
        comentariosHijos = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN>();
}



public ComentarioEN(int id, string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentariosHijos, PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN comentarioPadre
                    )
{
        this.init (Id, contenido, usuario, post, comentariosHijos, comentarioPadre);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Contenido, comentario.Usuario, comentario.Post, comentario.ComentariosHijos, comentario.ComentarioPadre);
}

private void init (int id
                   , string contenido, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN post, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> comentariosHijos, PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN comentarioPadre)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Usuario = usuario;

        this.Post = post;

        this.ComentariosHijos = comentariosHijos;

        this.ComentarioPadre = comentarioPadre;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
