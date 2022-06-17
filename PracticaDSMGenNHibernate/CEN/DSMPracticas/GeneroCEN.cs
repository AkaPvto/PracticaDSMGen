

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

public string New_ (string p_nombre)
{
        GeneroEN generoEN = null;
        string oid;

        //Initialized GeneroEN
        generoEN = new GeneroEN ();
        generoEN.Nombre = p_nombre;

        //Call to GeneroCAD

        oid = _IGeneroCAD.New_ (generoEN);
        return oid;
}

public void Modify (string p_Genero_OID)
{
        GeneroEN generoEN = null;

        //Initialized GeneroEN
        generoEN = new GeneroEN ();
        generoEN.Nombre = p_Genero_OID;
        //Call to GeneroCAD

        _IGeneroCAD.Modify (generoEN);
}

public void Destroy (string nombre
                     )
{
        _IGeneroCAD.Destroy (nombre);
}
}
}
