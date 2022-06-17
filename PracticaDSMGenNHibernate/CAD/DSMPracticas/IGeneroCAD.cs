
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IGeneroCAD
{
GeneroEN ReadOIDDefault (string nombre
                         );

void ModifyDefault (GeneroEN genero);

System.Collections.Generic.IList<GeneroEN> ReadAllDefault (int first, int size);



string New_ (GeneroEN genero);

void Modify (GeneroEN genero);


void Destroy (string nombre
              );
}
}
