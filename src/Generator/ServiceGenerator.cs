using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InfusionSoft.Definition;

namespace Generator
{
    class ServiceGenerator
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
                Interface = GeneratePart(type, InterfaceDirectory, _interfaceGenerator),
                Wrapper = GeneratePart(type, WrapperDirectory, _wrapperGenerator)
            }).ToArray();
        }

        private void Init()
        {
            if(InterfaceDirectory==null || WrapperDirectory == null)
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
            
            using(var stream = File.Create(fileName))
            using(var writer = new StreamWriter(stream))
            {
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
            var type = typeof(IServiceDefinition);
            var types = _assembly.GetTypes().Where(type.IsAssignableFrom);
            return types.Where(t => t != type);
        }
    }
}