

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;

using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
/*
 *      Definition of the class JuegoCEN
 *
 */
public partial class JuegoCEN
{
private IJuegoCAD _IJuegoCAD;

public JuegoCEN()
{
        this._IJuegoCAD = new JuegoCAD ();
}

public JuegoCEN(IJuegoCAD _IJuegoCAD)
{
        this._IJuegoCAD = _IJuegoCAD;
}

public IJuegoCAD get_IJuegoCAD ()
{
        return this._IJuegoCAD;
}

public string New_ (string p_nombre, string p_descripcion, string p_portada, System.Collections.Generic.IList<string> p_genero)
{
        JuegoEN juegoEN = null;
        string oid;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.Nombre = p_nombre;

        juegoEN.Descripcion = p_descripcion;

        juegoEN.Portada = p_portada;


        juegoEN.Genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
        if (p_genero != null) {
                foreach (string item in p_genero) {
                        PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN en = new PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN ();
                        en.Nombre = item;
                        juegoEN.Genero.Add (en);
                }
        }

        else{
                juegoEN.Genero = new System.Collections.Generic.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
        }

        //Call to JuegoCAD

        oid = _IJuegoCAD.New_ (juegoEN);
        return oid;
}

public void Modify (string p_Juego_OID, string p_descripcion, string p_portada)
{
        JuegoEN juegoEN = null;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.Nombre = p_Juego_OID;
        juegoEN.Descripcion = p_descripcion;
        juegoEN.Portada = p_portada;
        //Call to JuegoCAD

        _IJuegoCAD.Modify (juegoEN);
}

public void Destroy (string nombre
                     )
{
        _IJuegoCAD.Destroy (nombre);
}

public JuegoEN ReadOID (string nombre
                        )
{
        JuegoEN juegoEN = null;

        juegoEN = _IJuegoCAD.ReadOID (nombre);
        return juegoEN;
}

public System.Collections.Generic.IList<JuegoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<JuegoEN> list = null;

        list = _IJuegoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string nombre)
{
        return _IJuegoCAD.Busqueda (nombre);
}
}
}
