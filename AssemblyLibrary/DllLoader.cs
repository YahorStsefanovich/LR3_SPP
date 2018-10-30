using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class DllLoader
     {
          private DllDefinition result;
          private Assembly assembly;

          public DllLoader()
          {
               result = new DllDefinition();
          }

          public DllDefinition Read(string path)
          {
               assembly = Assembly.LoadFrom(path);

               foreach (var type in assembly.DefinedTypes)
               {
                    if ((result.NamespaceDefinitions.Find(x => x.Name == type.Namespace) == null)
                        && (type.Namespace != null))
                    {
                         result.NamespaceDefinitions.Add(new NamespaceDefinition(type.Namespace));
                    }
               }

               foreach (var nameSpace in result.NamespaceDefinitions)
               {
                    foreach (var type in assembly.DefinedTypes.Where(x => x.Namespace == nameSpace.Name))
                    {
                         nameSpace.TypeDefinitionInfo.Add(new TypeDefinition(type));
                    }
               }

               return result;
          }
     }
}
