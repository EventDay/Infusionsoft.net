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
using System.Linq;
using System.Reflection;
using InfusionSoft;

namespace Generator
{
    internal class ServiceInterfaceGenerator : IServicePartGenerator
    {
        public CodeCompileUnit Generate(Type definitionType, out string name)
        {
            name = definitionType.Name.Replace("Definition", "");

            var unit = new CodeCompileUnit();
            var globalNs = new CodeNamespace();
            globalNs.Imports.AddRange(new[]
                                {
                                    new CodeNamespaceImport("System"),
                                    new CodeNamespaceImport("System.Collections.Generic")
                                });
            unit.Namespaces.Add(globalNs);
            var ns = new CodeNamespace("InfusionSoft");

            
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
            method.Parameters.AddRange(
                parameters.Select(p => new CodeParameterDeclarationExpression(p.ParameterType, p.Name)).ToArray());

            target.Members.Add(method);
        }
    }
}