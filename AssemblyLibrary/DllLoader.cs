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
                    if ((result.Namespaces.Find(x => x.NamespaceName == type.Namespace) == null)
                        && (type.Namespace != null))
                    {
                         result.Namespaces.Add(new NamespaceDefinition(type.Namespace));
                    }
               }

               foreach (var nameSpace in result.Namespaces)
               {
                    foreach (var type in assembly.DefinedTypes.Where(x => x.Namespace == nameSpace.NamespaceName))
                    {
                         nameSpace.Types.Add(new TypeDefinition(type));
                    }
               }

               return result;
          }
     }
}
