using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class PropertyDefinition
     {
          private string propertyName;

          public PropertyDefinition(PropertyInfo propertyInfo)
          {
               this.PropertyName = String.Format("{0} {1}", propertyInfo.PropertyType.Name, propertyInfo.Name);
          }

          public string PropertyName
          {
               get
               {
                    return propertyName;
               }

               set
               {
                    propertyName = value;
               }
          }
     }
}
