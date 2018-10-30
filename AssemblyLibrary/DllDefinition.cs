﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLibrary
{
     public class DllDefinition
     {
          public List<NamespaceDefinition> Namespaces{ set; get; }

          public DllDefinition()
          {
               Namespaces = new List<NamespaceDefinition>();
          }
     }
}
