using System;
using System.CodeDom;

namespace Generator
{
    internal interface IServicePartGenerator
    {
        CodeCompileUnit Generate(Type definitionType, out string name);
    }
}