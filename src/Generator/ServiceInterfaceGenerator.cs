using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using InfusionSoft;

namespace Generator
{
    class ServiceInterfaceGenerator : IServicePartGenerator
    {
        public CodeCompileUnit Generate(Type definitionType, out string name)
        {
            name = definitionType.Name.Replace("Definition", "");

            var unit = new CodeCompileUnit();
            
            var ns = new CodeNamespace("InfusionSoft");
            
            ns.Imports.AddRange(new[]
            {
                new CodeNamespaceImport("System"),
                new CodeNamespaceImport("System.Collections.Generic")
            });

            var target = new CodeTypeDeclaration(name)
            {
                IsInterface = true,
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Interface
            };

            target.BaseTypes.Add(new CodeTypeReference(typeof (IService)));

            AddMethods(definitionType, target);

            ns.Types.Add(target);

            unit.Namespaces.Add(ns);

            return unit;
        }

        private void AddMethods(Type type, CodeTypeDeclaration target)
        {
            foreach (var method in type.GetMethods())
            {
                AddMethod(method, target);
            }
        }

        private void AddMethod(MethodInfo info, CodeTypeDeclaration target)
        {
            var method = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = info.Name,
                ReturnType = new CodeTypeReference(info.ReturnType)
            };

            //skip the apikey parameter.
            var parameters = info.GetParameters().Skip(1);
            method.Parameters.AddRange(parameters.Select(p => new CodeParameterDeclarationExpression(p.ParameterType, p.Name)).ToArray());

            target.Members.Add(method);
        }
    }
}