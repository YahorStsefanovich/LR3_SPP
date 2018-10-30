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
          private string methodName;

          public MethodDefinition(MethodInfo methodInfo)
          {
               MethodName = TypeModifier.GetTypeDefinition(methodInfo.GetType()) + methodInfo.ToString();
          }

          public string MethodName
          {
               get
               {
                    return methodName;
               }

               set
               {
                    methodName = value;
               }
          }
     }
}
