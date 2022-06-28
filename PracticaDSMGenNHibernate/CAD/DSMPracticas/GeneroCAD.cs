
using System;
using System.Text;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.Exceptions;


/*
 * Clase Genero:
 *
 */

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial class GeneroCAD : BasicCAD, IGeneroCAD
{
public GeneroCAD() : base ()
{
}

public GeneroCAD(ISession sessionAux) : base (sessionAux)
{
}



public GeneroEN ReadOIDDefault (int id
                                )
{
        GeneroEN generoEN = null;

        try
        {
                SessionInitializeTransaction ();
                generoEN = (GeneroEN)session.Get (typeof(GeneroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return generoEN;
}

public System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GeneroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GeneroEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GeneroEN>();
                        else
                                result = session.CreateCriteria (typeof(GeneroEN)).List<GeneroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Id);

                generoEN.Nombre = genero.Nombre;


                session.Update (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (genero);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return genero.Id;
}

public void Modify (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Id);

                generoEN.Nombre = genero.Nombre;

                session.Update (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), id);
                session.Delete (generoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> GetGenerosJuego (int p_juego)
{
        System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GeneroEN self where SELECT generos FROM GeneroEN as generos INNER JOIN generos.Juego as juegos WHERE juegos.Id = :p_juego";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GeneroENgetGenerosJuegoHQL");
                query.SetParameter ("p_juego", p_juego);

                result = query.List<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN GetIdPorNombre (string arg0)
{
        PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GeneroEN self where FROM GeneroEN WHERE GeneroEn.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GeneroENgetIdPorNombreHQL");
                query.SetParameter ("arg0", arg0);


                result = query.UniqueResult<PracticaDSMGenNHibernate.EN.DSMPracticas.GeneroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: GeneroEN
public GeneroEN ReadOID (int id
                         )
{
        GeneroEN generoEN = null;

        try
        {
                SessionInitializeTransaction ();
                generoEN = (GeneroEN)session.Get (typeof(GeneroEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return generoEN;
}

public System.Collections.Generic.IList<GeneroEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GeneroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GeneroEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GeneroEN>();
                else
                        result = session.CreateCriteria (typeof(GeneroEN)).List<GeneroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaDSMGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaDSMGenNHibernate.Exceptions.DataLayerException ("Error in GeneroCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
