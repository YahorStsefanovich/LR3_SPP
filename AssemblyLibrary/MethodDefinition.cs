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
               ParameterInfo[] pi = methodInfo.GetParameters();
               string pars = "";
               foreach (ParameterInfo par in pi)
               {
                    pars += String.Format("{0} {1},", par.ParameterType.Name, par.Name);
               }
               if (pars.Length > 0)
               pars = pars.Substring(0, pars.Length - 1);

               methodName = String.Format("{0} {1} {2} ({3})", 
                    TypeModifier.GetAccessModifier(methodInfo.GetType()),
                    methodInfo.ReturnType.Name,
                    methodInfo.Name,
                    pars);             
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
