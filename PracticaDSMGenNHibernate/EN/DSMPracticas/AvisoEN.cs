
using System;
// Definición clase AvisoEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class AvisoEN
{
/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario;



/**
 *	Atributo hora
 */
private Nullable<DateTime> hora;






public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Hora {
        get { return hora; } set { hora = value;  }
}





public AvisoEN()
{
}



public AvisoEN(int id, string texto, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, Nullable<DateTime> hora
               )
{
        this.init (Id, texto, usuario, hora);
}


public AvisoEN(AvisoEN aviso)
{
        this.init (Id, aviso.Texto, aviso.Usuario, aviso.Hora);
}

private void init (int id
                   , string texto, PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN usuario, Nullable<DateTime> hora)
{
        this.Id = id;


        this.Texto = texto;

        this.Usuario = usuario;

        this.Hora = hora;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AvisoEN t = obj as AvisoEN;
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
