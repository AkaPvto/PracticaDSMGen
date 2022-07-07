

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
 *      Definition of the class AvisoCEN
 *
 */
public partial class AvisoCEN
{
private IAvisoCAD _IAvisoCAD;

public AvisoCEN()
{
        this._IAvisoCAD = new AvisoCAD ();
}

public AvisoCEN(IAvisoCAD _IAvisoCAD)
{
        this._IAvisoCAD = _IAvisoCAD;
}

public IAvisoCAD get_IAvisoCAD ()
{
        return this._IAvisoCAD;
}

public void Modify (int p_Aviso_OID, string p_texto, Nullable<DateTime> p_hora)
{
        AvisoEN avisoEN = null;

        //Initialized AvisoEN
        avisoEN = new AvisoEN ();
        avisoEN.Id = p_Aviso_OID;
        avisoEN.Texto = p_texto;
        avisoEN.Hora = p_hora;
        //Call to AvisoCAD

        _IAvisoCAD.Modify (avisoEN);
}

public void Destroy (int id
                     )
{
        _IAvisoCAD.Destroy (id);
}

public AvisoEN ReadOID (int id
                        )
{
        AvisoEN avisoEN = null;

        avisoEN = _IAvisoCAD.ReadOID (id);
        return avisoEN;
}

public System.Collections.Generic.IList<AvisoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AvisoEN> list = null;

        list = _IAvisoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> GetAvisosUsu (int ? p_usu)
{
        return _IAvisoCAD.GetAvisosUsu (p_usu);
}
}
}
