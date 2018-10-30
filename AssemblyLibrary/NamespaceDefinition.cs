using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class NamespaceDefinition
     {
          public string Name { set; get; }
          
          public List<TypeDefinition> TypeDefinitionInfo { set; get; }
          
          public NamespaceDefinition(string name)
          {
               this.Name = name;
               TypeDefinitionInfo = new List<TypeDefinition>();
          }        
     }
}
