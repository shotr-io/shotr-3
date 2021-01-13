using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.Serialization;
using Shotr.Core.Custom;
using Shotr.Core.Entities;

namespace Shotr.Core.Utils
{
    class SettingsSerializationBinder : SerializationBinder
    {
        private readonly bool _searchInDlls;
        private readonly Assembly _currentAssembly;

        public SettingsSerializationBinder()
        {
            _currentAssembly = Assembly.GetExecutingAssembly();
            _searchInDlls = true;
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            var assemblyNames = new List<AssemblyName>();
            assemblyNames.Add(_currentAssembly.GetName()); // EXE

            if (_searchInDlls)
            {
                assemblyNames.AddRange(_currentAssembly.GetReferencedAssemblies()); // DLLs
            }

            foreach (AssemblyName an in assemblyNames)
            {
                var typeToDeserialize = GetTypeToDeserialize(typeName, an);
                if (typeToDeserialize != null)
                {
                    return typeToDeserialize;
                }
            }

            return null; // not found
        }

        private static Type GetTypeToDeserialize(string typeName, AssemblyName an)
        {
            string fullTypeName = string.Format("{0}, {1}", typeName, an.FullName);
            return typeName switch
            {
                "Shotr.CompressionLevel" => typeof(CompressionLevel),
                "Shotr.UploaderBridge" => typeof(UploaderBridge),
                "System.Collections.CaseInsensitiveHashCodeProvider" => typeof(CaseInsensitiveHashCode),
                var p when p.Contains("NameValueCollection") => typeof(Nvc),
                var p when p.Contains("CustomUploaderInstance") => typeof(CustomUploaderInstance),
                _ => Type.GetType(fullTypeName)
            };
        }
    }

    [Serializable]
    public class Nvc : NameValueCollection
    {
    }

    [Serializable()]
    public class CaseInsensitiveHashCode : System.Collections.CaseInsensitiveHashCodeProvider
    {
    }
}
