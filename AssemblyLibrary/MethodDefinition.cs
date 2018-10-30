using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class MethodDefinition
     {
          public string methodDefinition;

          public MethodDefinition(MethodInfo methodInfo)
          {
               methodDefinition = TypeModifier.GetTypeDefinition(methodInfo.GetType()) + methodInfo.ToString();
          }
     }
}
