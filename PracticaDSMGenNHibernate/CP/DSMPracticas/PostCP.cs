
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using PracticaDSMGenNHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;



namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class PostCP : BasicCP
{
public PostCP() : base ()
{
}

public PostCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
