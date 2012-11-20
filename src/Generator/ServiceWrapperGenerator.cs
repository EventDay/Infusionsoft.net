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
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfusionSoft;

namespace Generator
{
    internal class ServiceWrapperGenerator : IServicePartGenerator
    {
        public CodeCompileUnit Generate(Type definitionType, out string name)
        {
            name = definitionType.Name.Substring(1).Replace("Definition", "Wrapper");

            var unit = new CodeCompileUnit();
            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(new[]
                                {
                                    new CodeNamespaceImport("InfusionSoft.Definition")
                                });
            unit.Namespaces.Add(globalNs);

            var ns = new CodeNamespace("InfusionSoft");

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
            if (allParameters.Length > 1)
                parameters = allParameters.Skip(1).ToArray();

            method.Parameters.AddRange(
                parameters.Select(p => new CodeParameterDeclarationExpression(p.ParameterType, p.Name)).ToArray());

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
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (IInfusionSoftConfiguration),
                                                                              "configuration"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (IMethodListenerProvider),
                                                                              "listenerProvider"));

            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("configuration"));
            constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression("listenerProvider"));

            target.Members.Add(constructor);
        }
    }
}