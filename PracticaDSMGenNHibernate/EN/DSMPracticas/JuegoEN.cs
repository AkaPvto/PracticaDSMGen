
using System;
// Definición clase JuegoEN
namespace PracticaDSMGenNHibernate.EN.DSMPracticas
{
public partial class JuegoEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario;



/**
 *	Atributo comunidad
 */
private PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad;



/**
 *	Atributo portada
 */
private string portada;



/**
 *	Atributo genero
 */
private System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> genero;



/**
 *	Atributo id
 */
private int id;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN Comunidad {
        get { return comunidad; } set { comunidad = value;  }
}



public virtual string Portada {
        get { return portada; } set { portada = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> Genero {
        get { return genero; } set { genero = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public JuegoEN()
{
        usuario = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN>();
        genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
}



public JuegoEN(int id, string nombre, string descripcion, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, string portada, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> genero
               )
{
        this.init (Id, nombre, descripcion, usuario, comunidad, portada, genero);
}


public JuegoEN(JuegoEN juego)
{
        this.init (Id, juego.Nombre, juego.Descripcion, juego.Usuario, juego.Comunidad, juego.Portada, juego.Genero);
}

private void init (int id
                   , string nombre, string descripcion, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> usuario, PracticaDSMGenNHibernate.EN.DSMPracticas.ComunidadEN comunidad, string portada, System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> genero)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Usuario = usuario;

        this.Comunidad = comunidad;

        this.Portada = portada;

        this.Genero = genero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        JuegoEN t = obj as JuegoEN;
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
