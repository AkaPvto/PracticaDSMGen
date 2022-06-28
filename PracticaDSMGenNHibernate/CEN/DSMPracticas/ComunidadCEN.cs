

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
 *      Definition of the class ComunidadCEN
 *
 */
public partial class ComunidadCEN
{
private IComunidadCAD _IComunidadCAD;

public ComunidadCEN()
{
        this._IComunidadCAD = new ComunidadCAD ();
}

public ComunidadCEN(IComunidadCAD _IComunidadCAD)
{
        this._IComunidadCAD = _IComunidadCAD;
}

public IComunidadCAD get_IComunidadCAD ()
{
        return this._IComunidadCAD;
}

public void DeletePost (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs)
{
        //Call to ComunidadCAD

        _IComunidadCAD.DeletePost (p_Comunidad_OID, p_post_OIDs);
}
public int New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fechaCreacion, int p_juego)
{
        ComunidadEN comunidadEN = null;
        int oid;

        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Nombre = p_nombre;

        comunidadEN.Descripcion = p_descripcion;

        comunidadEN.FechaCreacion = p_fechaCreacion;


        if (p_juego != -1) {
                // El argumento p_juego -> Property juego es oid = false
                // Lista de oids id
                comunidadEN.Juego = new PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN ();
                comunidadEN.Juego.Id = p_juego;
        }

        //Call to ComunidadCAD

        oid = _IComunidadCAD.New_ (comunidadEN);
        return oid;
}

public void Modify (int p_Comunidad_OID, string p_nombre, string p_descripcion, Nullable<DateTime> p_fechaCreacion)
{
        ComunidadEN comunidadEN = null;

        //Initialized ComunidadEN
        comunidadEN = new ComunidadEN ();
        comunidadEN.Id = p_Comunidad_OID;
        comunidadEN.Nombre = p_nombre;
        comunidadEN.Descripcion = p_descripcion;
        comunidadEN.FechaCreacion = p_fechaCreacion;
        //Call to ComunidadCAD

        _IComunidadCAD.Modify (comunidadEN);
}

public void Destroy (int id
                     )
{
        _IComunidadCAD.Destroy (id);
}

public ComunidadEN ReadOID (int id
                            )
{
        ComunidadEN comunidadEN = null;

        comunidadEN = _IComunidadCAD.ReadOID (id);
        return comunidadEN;
}

public System.Collections.Generic.IList<ComunidadEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComunidadEN> list = null;

        list = _IComunidadCAD.ReadAll (first, size);
        return list;
}
public void AddUsuarios (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to ComunidadCAD

        _IComunidadCAD.AddUsuarios (p_Comunidad_OID, p_usuario_OIDs);
}
public void DeleteUsuarios (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to ComunidadCAD

        _IComunidadCAD.DeleteUsuarios (p_Comunidad_OID, p_usuario_OIDs);
}
public void AddPost (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs)
{
        //Call to ComunidadCAD

        _IComunidadCAD.AddPost (p_Comunidad_OID, p_post_OIDs);
}
}
}
