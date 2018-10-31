using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyLibrary;
using System.Linq;

namespace Tests
{
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
               Assert.IsTrue(result.Namespaces.Count > 0);
          }

          [TestMethod]
          public void TestNamespaceName()
          {
               Assert.AreEqual(result.Namespaces[0].NamespaceName, nameof(Tests));
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
