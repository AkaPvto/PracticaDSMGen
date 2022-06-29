

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
 *      Definition of the class GeneroCEN
 *
 */
public partial class GeneroCEN
{
private IGeneroCAD _IGeneroCAD;

public GeneroCEN()
{
        this._IGeneroCAD = new GeneroCAD ();
}

public GeneroCEN(IGeneroCAD _IGeneroCAD)
{
        this._IGeneroCAD = _IGeneroCAD;
}

public IGeneroCAD get_IGeneroCAD ()
{
        return this._IGeneroCAD;
}

public int New_ (string p_nombre)
{
        GeneroEN generoEN = null;
        int oid;

        //Initialized GeneroEN
        generoEN = new GeneroEN ();
        generoEN.Nombre = p_nombre;

        //Call to GeneroCAD

        oid = _IGeneroCAD.New_ (generoEN);
        return oid;
}

public void Modify (int p_Genero_OID, string p_nombre)
{
        GeneroEN generoEN = null;

        //Initialized GeneroEN
        generoEN = new GeneroEN ();
        generoEN.Id = p_Genero_OID;
        generoEN.Nombre = p_nombre;
        //Call to GeneroCAD

        _IGeneroCAD.Modify (generoEN);
}

public void Destroy (int id
                     )
{
        _IGeneroCAD.Destroy (id);
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> GetGenerosJuego (int p_juego)
{
        return _IGeneroCAD.GetGenerosJuego (p_juego);
}
public PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN GetIdPorNombre (string p_nombre)
{
        return _IGeneroCAD.GetIdPorNombre (p_nombre);
}
public GeneroEN ReadOID (int id
                         )
{
        GeneroEN generoEN = null;

        generoEN = _IGeneroCAD.ReadOID (id);
        return generoEN;
}

public System.Collections.Generic.IList<GeneroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GeneroEN> list = null;

        list = _IGeneroCAD.ReadAll (first, size);
        return list;
}
}
}
