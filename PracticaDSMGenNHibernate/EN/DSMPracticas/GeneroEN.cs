
using System;
// Definición clase GeneroEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class GeneroEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo juego
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego;



/**
 *	Atributo id
 */
private int id;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Juego {
        get { return juego; } set { juego = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public GeneroEN()
{
        juego = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN>();
}



public GeneroEN(int id, string nombre, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego
                )
{
        this.init (Id, nombre, juego);
}


public GeneroEN(GeneroEN genero)
{
        this.init (Id, genero.Nombre, genero.Juego);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> juego)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Juego = juego;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GeneroEN t = obj as GeneroEN;
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
