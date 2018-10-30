using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class DllDefinition
     {
          public List<NamespaceDefinition> NamespaceDefinitions { set; get; }

          public DllDefinition()
          {
               NamespaceDefinitions = new List<NamespaceDefinition>();
          }
     }
}
