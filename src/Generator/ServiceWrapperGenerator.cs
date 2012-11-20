using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfusionSoft;

namespace Generator
{
    class ServiceWrapperGenerator : IServicePartGenerator
    {
        public CodeCompileUnit Generate(Type definitionType, out string name)
        {
            name = definitionType.Name.Substring(1).Replace("Definition", "Wrapper");

            var unit = new CodeCompileUnit();
            var ns = new CodeNamespace("InfusionSoft");

            ns.Imports.AddRange(new[]
            {
                new CodeNamespaceImport("Definition")
            });
            
            var target = new CodeTypeDeclaration(name)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.NotPublic | TypeAttributes.Class,
                IsPartial = true
            };

            target.BaseTypes.AddRange(new[]
            {
                new CodeTypeReference(string.Format("ServiceBase<{0}>", definitionType.Name)), 
                new CodeTypeReference(definitionType.Name.Replace("Definition", ""))
            });

            AddConstructor(target);
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
                ReturnType = new CodeTypeReference(info.ReturnType),
            };

            var allParameters = info.GetParameters().ToArray();
            
            var parameters = new ParameterInfo[0];
            if(allParameters.Length > 1)
                parameters = allParameters.Skip(1).ToArray();

            method.Parameters.AddRange(parameters.Select(p => new CodeParameterDeclarationExpression(p.ParameterType, p.Name)).ToArray());
            
            //Invoke
            var statement = new CodeMethodReturnStatement();

            string parms = GetInvokeParametersString(parameters);

            statement.Expression = new CodeSnippetExpression(string.Format("Invoke(d => d.{0}({1}))", info.Name, parms));
            
            method.Statements.Add(statement);

            target.Members.Add(method);
        }

        private string GetInvokeParametersString(IEnumerable<ParameterInfo> parameters)
        {
            var list = parameters.Select(p => p.Name).ToList();
            list.Insert(0, "ApiKey");
            return string.Join(", ", list);
        }

        private void AddConstructor(CodeTypeDeclaration target)
        {
            // Declare the constructor
            var constructor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };

            // Add parameters.
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(IInfusionSoftConfiguration), "configuration"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (IMethodListenerProvider),
                                                                              "listenerProvider"));

            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("configuration"));
            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("listenerProvider"));
            
            target.Members.Add(constructor);
        }
    }
}