using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public static class TypeModifier
     {
          public static string GetAccessModifier(Type type)
          {
               string result = "";
               TypeAttributes attr = type.Attributes;

               // To test for visibility attributes, you must use the visibility mask.
               TypeAttributes visibility = attr & TypeAttributes.VisibilityMask;
               switch (visibility)
               {
                    case TypeAttributes.NotPublic:
                    case TypeAttributes.NestedPrivate:
                         result = "private";
                         break;

                    case TypeAttributes.Public:
                    case TypeAttributes.NestedPublic:
                         result = "public";
                         break;

                    case TypeAttributes.NestedAssembly:
                         result = "internal";
                         break;

                    case TypeAttributes.NestedFamily:
                         result = "protected";
                         break;
                    case TypeAttributes.NestedFamORAssem:
                         result = "protected internal";
                         break;
                    default:
                         result = "public";
                         break;
               }

               return result;
          }

          private static string GetTypeAtributes(Type type)
          {
               string result = "";
               TypeAttributes attr = type.Attributes;

               if ((attr & TypeAttributes.Abstract) != 0)
               {
                    result += "abstract ";
               }

               if ((attr & TypeAttributes.Sealed) != 0)
               {
                    result += "sealed ";
               }

               if ((attr & TypeAttributes.Abstract & TypeAttributes.Sealed) != 0)
               {
                    result = "static";
               }

               return result;
          }

          private static string GetClassSemantics(Type type)
          {
               string result = "";
               TypeAttributes attr = type.Attributes;

               // Use the class semantics mask to test for class semantics attributes.
               TypeAttributes classSemantics = attr & TypeAttributes.ClassSemanticsMask;

               switch (classSemantics)
               {
                    case TypeAttributes.Class:
                         result = type.IsValueType ? "struct" : "class";
                         break;
                    case TypeAttributes.Interface:
                         result = "interface";
                         break;
                    default:
                         if (type.IsEnum)
                              result =  "enum";
                         
                         if (type.BaseType == typeof(MulticastDelegate))
                              result = "delegate";
                         break;
               }

               return result;
          }

          public static string GetTypeDefinition(Type type)
          {
               string result = String.Format("{0} {1} {2}",
                    GetAccessModifier(type),
                    GetTypeAtributes(type),
                    GetClassSemantics(type)
                    );
               return result;
          }
     }
}
