
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IGeneroCAD
{
GeneroEN ReadOIDDefault (int id
                         );

void ModifyDefault (GeneroEN genero);

System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size);



int New_ (GeneroEN genero);

void Modify (GeneroEN genero);


void Destroy (int id
              );
}
}
