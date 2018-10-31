using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyLibrary;
using System.Linq;

namespace Tests
{
     namespace Namespace1
     {
          public class Class1
          {
               public string Field1;
               public int Field2;
          }

          interface I1
          {

          } 
     }

     [TestClass]
     public class TestClass
     {
          private DllDefinition result;
          private Type classType;
          private string path = "./Tests.dll";

          [TestInitialize]
          public void Initialize()
          {
               DllLoader loader = new DllLoader();
               result = loader.Read(path);
               classType = typeof(TestClass);
          }



          [TestMethod]
          public void TestNamespaceExists()
          {
               Assert.IsNotNull(result.Namespaces);
          }

          [TestMethod]
          public void TestNamespacesCount()
          {
               Assert.AreEqual(result.Namespaces.Count, 2);
          }

          [TestMethod]
          public void TestNamespaceName()
          {
               Assert.AreEqual(result.Namespaces[0].NamespaceName, nameof(Tests));
          }

          [TestMethod]
          public void TestInterfaceExists()
          {
               Boolean actual = false;
               foreach (TypeDefinition td in result.Namespaces[1].Types)
               {
                    if (td.TypeName.Contains("interface"))
                         actual = true;
               }
               Assert.IsTrue(actual);
          }

          [TestMethod]
          public void TestClassExists()
          {
               Boolean actual = false;
               foreach (TypeDefinition td in result.Namespaces[1].Types)
               {
                    if (td.TypeName.Contains("class"))
                         actual = true;
               }
               Assert.IsTrue(actual);
          }

          [TestMethod]
          public void TestNamespacesTypesCount()
          {
               foreach (NamespaceDefinition ns in result.Namespaces)
               {
                    Assert.IsTrue(ns.Types.Count > 0);
               }
          }

          [TestMethod]
          public void TestTypeFieldsCount()
          {
               int actualCount = result.Namespaces[0].Types[0].Fields.Count;
               int expectedCount = classType.GetFields().Length;
               Assert.AreEqual(actualCount, expectedCount);
          }

          [TestMethod]
          public void TestTypePropertiesCount()
          {
               int actualCount = result.Namespaces[0].Types[0].Propierties.Count;
               int expectedCount = classType.GetProperties().Length;
               Assert.AreEqual(actualCount, expectedCount);
          }

          [TestMethod]
          public void TestTypeMethodsCount()
          {
               int actualCount = result.Namespaces[0].Types[0].Methods.Count;
               int expectedCount = classType.GetMethods().Where(item => !item.IsSpecialName).Count();
               Assert.AreEqual(actualCount, expectedCount);
          }
     }
}

