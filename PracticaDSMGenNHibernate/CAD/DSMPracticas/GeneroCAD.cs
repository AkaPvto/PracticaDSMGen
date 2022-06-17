
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



public GeneroEN ReadOIDDefault (string nombre
                                )
{
        GeneroEN generoEN = null;

        try
        {
                SessionInitializeTransaction ();
                generoEN = (GeneroEN)session.Get (typeof(GeneroEN), nombre);
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
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Nombre);

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


public string New_ (GeneroEN genero)
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

        return genero.Nombre;
}

public void Modify (GeneroEN genero)
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), genero.Nombre);
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
public void Destroy (string nombre
                     )
{
        try
        {
                SessionInitializeTransaction ();
                GeneroEN generoEN = (GeneroEN)session.Load (typeof(GeneroEN), nombre);
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
}
}
