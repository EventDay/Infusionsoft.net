using System;

namespace Generator
{
    class Service
    {
        public Service(Type definitionType)
        {
            DefinitionType = definitionType;
        }

        public Type DefinitionType { get; private set; }
        public ServiceFile Interface { get; set; }
        public ServiceFile Wrapper { get; set; }
    }
}