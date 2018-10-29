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
          public string propertyName;
          public string ptopertyType;

          public PropertyDefinition(PropertyInfo propertyInfo)
          {
               this.propertyName = propertyInfo.Name;
               this.ptopertyType = propertyInfo.PropertyType.Name;
          }
     }
}
