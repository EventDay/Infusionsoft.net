#region License

// Copyright (c) 2012, EventDay
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InfusionSoft.Definition;

namespace Generator
{
    internal class ServiceGenerator
    {
        private readonly Assembly _assembly;
        private readonly Lazy<IEnumerable<Type>> _definitionTypes;
        private readonly IServicePartGenerator _interfaceGenerator;
        private readonly ServiceWrapperGenerator _wrapperGenerator;

        public ServiceGenerator(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            _assembly = assembly;
            _definitionTypes = new Lazy<IEnumerable<Type>>(LoadDefinitions);
            _interfaceGenerator = new ServiceInterfaceGenerator();
            _wrapperGenerator = new ServiceWrapperGenerator();
        }

        public DirectoryInfo InterfaceDirectory { get; set; }

        public DirectoryInfo WrapperDirectory { get; set; }

        public Service[] Generate()
        {
            Init();

            return _definitionTypes.Value.Select(type => new Service(type)
                                                         {
                                                             Interface =
                                                                 GeneratePart(type, InterfaceDirectory,
                                                                              _interfaceGenerator),
                                                             Wrapper =
                                                                 GeneratePart(type, WrapperDirectory, _wrapperGenerator)
                                                         }).ToArray();
        }

        private void Init()
        {
            if (InterfaceDirectory == null || WrapperDirectory == null)
                throw new NotSupportedException("Must set InterfaceDirectory and WrapperDirectory properties.");

            if (Directory.Exists(InterfaceDirectory.FullName) == false)
                Directory.CreateDirectory(InterfaceDirectory.FullName);

            if (Directory.Exists(WrapperDirectory.FullName) == false)
                Directory.CreateDirectory(WrapperDirectory.FullName);
        }

//        private ServiceFile GenerateWrapper()
//        {
//            
//        }

        private ServiceFile GeneratePart(Type type, DirectoryInfo directory, IServicePartGenerator generator)
        {
            var provider = CodeDomProvider.CreateProvider("CSharp");
            
            var options = new CodeGeneratorOptions
                          {
                              BracingStyle = "C"
                          };

            string name;
            var unit = generator.Generate(type, out name);
            var fileName = Path.Combine(directory.FullName, string.Format("{0}.cs", name));

            using (var stream = File.Create(fileName))
            using (var writer = new StreamWriter(stream))
            {
                writer.WriteLine("#region License");
                writer.WriteLine();
                writer.WriteLine("// Copyright (c) 2012, EventDay");
                writer.WriteLine("// All rights reserved.");
                writer.WriteLine("// ");
                writer.WriteLine("// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:");
                writer.WriteLine("// ");
                writer.WriteLine("// Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.");
                writer.WriteLine("// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.");
                writer.WriteLine("// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS \"AS IS\" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.");
                writer.WriteLine();
                writer.WriteLine("#endregion");

                provider.GenerateCodeFromCompileUnit(unit, writer, options);
            }

            return new ServiceFile
                   {
                       File = new FileInfo(fileName),
                       Name = name
                   };
        }

        private IEnumerable<Type> LoadDefinitions()
        {
            var type = typeof (IServiceDefinition);
            var types = _assembly.GetTypes().Where(type.IsAssignableFrom);
            return types.Where(t => t != type);
        }
    }
}