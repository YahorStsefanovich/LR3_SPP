using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class TypeDefinition
     {
          public string TypeName { set; get; }

          public List<PropertyDefinition> Propierties
          {
               get
               {
                    return propierties;
               }

               set
               {
                    propierties = value;
               }
          }

          public List<FieldDefinition> Fields
          {
               get
               {
                    return fields;
               }

               set
               {
                    fields = value;
               }
          }

          public List<MethodDefinition> Methods
          {
               get
               {
                    return methods;
               }

               set
               {
                    methods = value;
               }
          }

          private List<PropertyDefinition> propierties;
          private List<FieldDefinition> fields;
          private List<MethodDefinition> methods;

          public TypeDefinition(TypeInfo type)
          {
               TypeName = String.Format("{0} {1}", TypeModifier.GetTypeDefinition(type), type.Name);
               Fields = GetFields(type);
               Propierties = GetPropierties(type);
               Methods = GetMethods(type);              
          }

          private List<FieldDefinition> GetFields(TypeInfo type)
          {
               List<FieldDefinition> list = new List<FieldDefinition>();
               var fields = type.GetFields();

               foreach (var field in fields)
               {
                    list.Add(new FieldDefinition(field));
               }

               return list; 
          }


          private List<PropertyDefinition> GetPropierties(TypeInfo type)
          {
               List<PropertyDefinition> list = new List<PropertyDefinition>();
               var propierties = type.GetProperties();

               foreach (var propierty in propierties)
               {
                    list.Add(new PropertyDefinition(propierty));
               }

               return list;
          }

          private List<MethodDefinition> GetMethods(Type type)
          {
               List<MethodDefinition> list = new List<MethodDefinition>();
               var methods = type.GetMethods();

               foreach (var method in methods)
               {
                    // Only display methods declared in this type. Also 
                    // filter out any methods with special names, because these
                    // cannot be generally called by the user. That is, their 
                    // functionality is usually exposed in other ways, for example,
                    // property get/set methods are exposed as properties.
                    if (!method.IsSpecialName)
                    {
                         list.Add(new MethodDefinition(method));
                    }
               }

               return list;
          }
     }
}
