using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class FieldDefinition
     {
          private string fieldName;
          private string fieldDefinition;

          public string FieldName
          {
               get
               {
                    return fieldDefinition;
               }

               set
               {
                    fieldName = value;
               }
          }

          public FieldDefinition(FieldInfo fieldInfo)
          {
               this.FieldName = fieldInfo.Name;
               this.fieldDefinition = String.Format("{0} {1} {2}", 
                    TypeModifier.GetAccessModifier(fieldInfo.GetType()),
                    fieldInfo.ReflectedType.Name,
                    fieldInfo.Name);


               //this.fieldDefinition += (fieldInfo.FieldType.IsGenericType ?
               //     String.Format("{0}<{1}>", fieldInfo.ReflectedType.Name, GetGenericType(fieldInfo.FieldType.GenericTypeArguments)) :
               //     fieldInfo.ReflectedType.Name);
          }

          private string GetGenericType(Type[] type)
          {
               string result = "";
               foreach (Type genericType in type)
               {
                    result += (type.GetType().IsGenericType ?
                         String.Format("<{0}>", GetGenericType(genericType.GetType().GenericTypeArguments)) :
                         String.Format("{0} ", genericType.Name));
               }

               return result;
          }

     }
}
