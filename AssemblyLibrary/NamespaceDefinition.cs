using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class NamespaceDefinition
     {
          public string NamespaceName { set; get; }
          
          public List<TypeDefinition> Types { set; get; }
          
          public NamespaceDefinition(string name)
          {
               NamespaceName = name;
               Types = new List<TypeDefinition>();
          }        
     }
}
