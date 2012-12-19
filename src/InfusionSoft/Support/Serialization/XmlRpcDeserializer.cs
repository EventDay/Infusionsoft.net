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
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml;
using CookComputing.XmlRpc;
using InfusionSoft.Tables;

namespace InfusionSoft.Serialization
{
    public class XmlRpcDeserializer
    {
        public XmlRpcNonStandard NonStandard { get; set; }

        protected bool AllowInvalidHttpContent
        {
            get { return (NonStandard & XmlRpcNonStandard.AllowInvalidHTTPContent) != XmlRpcNonStandard.None; }
        }

        protected bool AllowNonStandardDateTime
        {
            get { return (NonStandard & XmlRpcNonStandard.AllowNonStandardDateTime) != XmlRpcNonStandard.None; }
        }

        protected bool AllowStringFaultCode
        {
            get { return (NonStandard & XmlRpcNonStandard.AllowStringFaultCode) != XmlRpcNonStandard.None; }
        }

        protected bool IgnoreDuplicateMembers
        {
            get { return (NonStandard & XmlRpcNonStandard.IgnoreDuplicateMembers) != XmlRpcNonStandard.None; }
        }

        protected bool MapEmptyDateTimeToMinValue
        {
            get { return (NonStandard & XmlRpcNonStandard.MapEmptyDateTimeToMinValue) != XmlRpcNonStandard.None; }
        }

        protected bool MapZerosDateTimeToMinValue
        {
            get { return (NonStandard & XmlRpcNonStandard.MapZerosDateTimeToMinValue) != XmlRpcNonStandard.None; }
        }

        public object MapValueNode(IEnumerator<Node> iter, Type valType, MappingStack mappingStack,
                                   MappingAction mappingAction)
        {
            var valueNode = iter.Current as ValueNode;
            if (valType != null && valType.BaseType == null)
                valType = null;
            if (valueNode is StringValue && valueNode.ImplicitValue)
                CheckImplictString(valType, mappingStack);
            object obj = null;
            Type mappedType;
            if (iter.Current is ArrayValue)
                obj = MapArray(iter, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is StructValue)
            {
                if (valType != null && valType != typeof (XmlRpcStruct) && !valType.IsSubclassOf(typeof (XmlRpcStruct)))
                {
                    obj = MapStruct(iter, valType, mappingStack, mappingAction, out mappedType);
                }
                else
                {
                    if (valType == null || valType == typeof (object))
                        valType = typeof (XmlRpcStruct);
                    obj = MapHashtable(iter, valType, mappingStack, mappingAction, out mappedType);
                }
            }
            else if (iter.Current is Base64Value)
                obj = MapBase64(valueNode.Value, valType, mappingStack, out mappedType);
            else if (iter.Current is IntValue)
                obj = MapInt(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is LongValue)
                obj = MapLong(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is StringValue)
                obj = MapString(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is BooleanValue)
                obj = MapBoolean(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is DoubleValue)
                obj = MapDouble(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is DateTimeValue)
                obj = MapDateTime(valueNode.Value, valType, mappingStack, mappingAction, out mappedType);
            else if (iter.Current is NilValue)
                obj = MapNilValue(valType, mappingStack, out mappedType);
            return obj;
        }

        private object MapDateTime(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                                   out Type mappedType)
        {
            CheckExpectedType(valType, typeof (DateTime), mappingStack);
            mappedType = typeof (DateTime);
            return OnStack("dateTime", mappingStack, (() =>
            {
                if (value == "" && MapEmptyDateTimeToMinValue)
                    return DateTime.MinValue;
                DateTime local0;
                if (!DateTime8601.TryParseDateTime8601(value, out local0))
                {
                    if (MapZerosDateTimeToMinValue && value.StartsWith("0000") &&
                        (value == "00000000T00:00:00" || value == "0000-00-00T00:00:00Z" ||
                         (value == "00000000T00:00:00Z" || value == "0000-00-00T00:00:00")))
                        throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType +
                                                               " contains invalid dateTime value " +
                                                               StackDump(mappingStack));
                    local0 = DateTime.MinValue;
                }
                return local0;
            }));
        }

        private object MapDouble(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                                 out Type mappedType)
        {
            CheckExpectedType(valType, typeof (double), mappingStack);
            mappedType = typeof (double);
            return OnStack("double", mappingStack, (() =>
            {
                try
                {
                    return double.Parse(value, CultureInfo.InvariantCulture.NumberFormat);
                }
                catch (Exception exception0)
                {
                    throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType + " contains invalid double value " +
                                                           StackDump(mappingStack));
                }
            }));
        }

        private object MapBoolean(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                                  out Type mappedType)
        {
            CheckExpectedType(valType, typeof (bool), mappingStack);
            mappedType = typeof (bool);
            return OnStack("boolean", mappingStack, (() =>
            {
                if (value == "1")
                    return true;
                if (value == "0")
                    return false;
                throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType + " contains invalid boolean value " +
                                                       StackDump(mappingStack));
            }));
        }

        private object MapString(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                                 out Type mappedType)
        {
            CheckExpectedType(valType, typeof (string), mappingStack);
            if (valType != null && valType.IsEnum)
                return MapStringToEnum(value, valType, "i8", mappingStack, mappingAction, out mappedType);
            mappedType = typeof (string);
            return OnStack("string", mappingStack, (() => value));
        }

        private object MapStringToEnum(string value, Type enumType, string xmlRpcType, MappingStack mappingStack,
                                       MappingAction mappingAction, out Type mappedType)
        {
            mappedType = enumType;
            return OnStack(xmlRpcType, mappingStack, (() =>
            {
                try
                {
                    return Enum.Parse(enumType, value, true);
                }
                catch (XmlRpcInvalidEnumValue exception_0)
                {
                    throw;
                }
                catch (Exception exception_1)
                {
                    throw new XmlRpcInvalidEnumValue(mappingStack.MappingType + " contains invalid or out of range " +
                                                     xmlRpcType + " value mapped to enum " + StackDump(mappingStack));
                }
            }));
        }

        private object MapLong(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                               out Type mappedType)
        {
            CheckExpectedType(valType, typeof (long), mappingStack);
            if (valType != null && valType.IsEnum)
                return MapNumberToEnum(value, valType, "i8", mappingStack, out mappedType);
            mappedType = typeof (long);
            return OnStack("i8", mappingStack, (() =>
            {
                long local_0;
                if (!long.TryParse(value, out local_0))
                    throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType + " contains invalid i8 value " +
                                                           StackDump(mappingStack));
                return local_0;
            }));
        }

        private object MapInt(string value, Type valType, MappingStack mappingStack, MappingAction mappingAction,
                              out Type mappedType)
        {
            CheckExpectedType(valType, typeof (int), mappingStack);
            if (valType != null && valType.IsEnum)
                return MapNumberToEnum(value, valType, "int", mappingStack, out mappedType);
            mappedType = typeof (int);
            return OnStack("integer", mappingStack, (() =>
            {
                int local0;
                if (!int.TryParse(value, out local0))
                    throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType + " contains invalid int value " +
                                                           StackDump(mappingStack));
                return local0;
            }));
        }

        private object MapNumberToEnum(string value, Type enumType, string xmlRpcType, MappingStack mappingStack,
                                       out Type mappedType)
        {
            mappedType = enumType;
            return OnStack(xmlRpcType, mappingStack, (() =>
            {
                try
                {
                    object local2 = Convert.ChangeType(long.Parse(value), Enum.GetUnderlyingType(enumType), null);
                    if (Enum.IsDefined(enumType, local2))
                        return Enum.ToObject(enumType, local2);
                    throw new XmlRpcInvalidEnumValue(mappingStack.MappingType + " contains " + xmlRpcType +
                                                     "mapped to undefined enum value " + StackDump(mappingStack));
                }
                catch (XmlRpcInvalidEnumValue exception0)
                {
                    throw;
                }
                catch (Exception exception1)
                {
                    throw new XmlRpcInvalidEnumValue(mappingStack.MappingType + " contains invalid or out of range " +
                                                     xmlRpcType + " value mapped to enum " + StackDump(mappingStack));
                }
            }));
        }

        private object MapBase64(string value, Type valType, MappingStack mappingStack,
                                 out Type mappedType)
        {
            CheckExpectedType(valType, typeof (byte[]), mappingStack);
            mappedType = typeof (int);
            return OnStack("base64", mappingStack, (() =>
            {
                if (value == "")
                    return new byte[0];
                try
                {
                    return Convert.FromBase64String(value);
                }
                catch (Exception exception0)
                {
                    throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType + " contains invalid base64 value " +
                                                           StackDump(mappingStack));
                }
            }));
        }

        private object MapNilValue(Type type, MappingStack mappingStack,
                                   out Type mappedType)
        {
            if (type == null || type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>) ||
                (!type.IsPrimitive || !type.IsValueType || type == typeof (object)))
            {
                mappedType = type;
                return null;
            }
            throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType +
                                                   " contains <nil> value which cannot be mapped to type " +
                                                   (type == typeof (object) ? "object" : type.Name) +
                                                   " " + StackDump(mappingStack));
        }

        protected object MapHashtable(IEnumerator<Node> iter, Type valType, MappingStack mappingStack,
                                      MappingAction mappingAction, out Type mappedType)
        {
            mappedType = null;
            var xmlRpcStruct = new XmlRpcStruct();
            (mappingStack).Push("struct mapped to XmlRpcStruct");
            try
            {
                while (iter.MoveNext())
                {
                    if (iter.Current is StructMember)
                    {
                        string str = (iter.Current as StructMember).Value;
                        if (xmlRpcStruct.ContainsKey(str) && !IgnoreDuplicateMembers)
                        {
                            throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType +
                                                                   " contains struct value with duplicate member " + str +
                                                                   " " + StackDump(mappingStack));
                        }
                        else
                        {
                            iter.MoveNext();
                            object obj = OnStack(string.Format("member {0}", str), mappingStack,
                                                 (() => MapValueNode(iter, null, mappingStack, mappingAction)));
                            if (!xmlRpcStruct.ContainsKey(str))
                                xmlRpcStruct[str] = obj;
                        }
                    }
                    else
                        break;
                }
            }
            finally
            {
                mappingStack.Pop();
            }
            return xmlRpcStruct;
        }

        private object MapStruct(IEnumerator<Node> iter, Type valueType, MappingStack mappingStack,
                                 MappingAction mappingAction, out Type mappedType)
        {
            mappedType = null;
            if (valueType.IsPrimitive)
            {
                throw new XmlRpcTypeMismatchException(mappingStack.MappingType + " contains struct value where " +
                                                      XmlRpcTypeInfo.GetXmlRpcTypeString(valueType) + " expected " +
                                                      StackDump(mappingStack));
            }
            if (valueType.IsGenericType)
            {
                if (valueType.GetGenericTypeDefinition() == typeof (Nullable<>))
                    valueType = valueType.GetGenericArguments()[0];
            }
            object instance;
            try
            {
                instance = Activator.CreateInstance(valueType);
            }
            catch (Exception ex)
            {
                throw new XmlRpcTypeMismatchException(mappingStack.MappingType + " contains struct value where " +
                                                      XmlRpcTypeInfo.GetXmlRpcTypeString(valueType) +
                                                      " expected (as type " + valueType.Name + ") " +
                                                      StackDump(mappingStack));
            }
            MappingAction mappingAction1 = mappingAction;
            if (valueType != null)
            {
                (mappingStack).Push("struct mapped to type " + valueType.Name);
                mappingAction1 = StructMappingAction(valueType, mappingAction);
            }
            else
                (mappingStack).Push("struct");
            List<string> names = new List<string>();
            CreateFieldNamesMap(valueType, names);
            int num = 0;
            List<string> list = new List<string>();
            try
            {
                while (iter.MoveNext())
                {
                    if (iter.Current is StructMember)
                    {
                        string XmlRpcName = (iter.Current as StructMember).Value;
                        if (list.Contains(XmlRpcName))
                        {
                            if (!IgnoreDuplicateMembers)
                                throw new XmlRpcInvalidXmlRpcException(mappingStack.MappingType +
                                                                       " contains struct value with duplicate member " +
                                                                       XmlRpcName + " " + StackDump(mappingStack));
                        }
                        else
                        {
                            list.Add(XmlRpcName);
                            string name = GetStructName(valueType, XmlRpcName) ?? XmlRpcName;
                            MemberInfo element = valueType.GetField(name) ??
                                                 (MemberInfo) valueType.GetProperty(name);
                            if (element == null)
                            {
                                iter.MoveNext();
                                //If this is a table object, then we need to populate 
                                // the value in the custom fields dictionary.
                                if (valueType.IsSubclassOf(typeof (Table)))
                                {
                                    AddCustomField(iter, mappingStack, mappingAction, name, instance);
                                }
                                if (iter.Current is ComplexValueNode)
                                {
                                    int depth = iter.Current.Depth;
                                    while (!(iter.Current is EndComplexValueNode) || iter.Current.Depth != depth)
                                        iter.MoveNext();
                                }
                            }
                            else
                            {
                                if (names.Contains(name))
                                    names.Remove(name);
                                else if (Attribute.IsDefined(element, typeof (NonSerializedAttribute)))
                                {
                                    (mappingStack).Push(string.Format("member {0}", name));
                                    throw new XmlRpcNonSerializedMember(
                                        "Cannot map XML-RPC struct member onto member marked as [NonSerialized]:  " +
                                        StackDump(mappingStack));
                                }
                                Type memberType = element.MemberType == MemberTypes.Field
                                                      ? (element as FieldInfo).FieldType
                                                      : (element as PropertyInfo).PropertyType;
                                string p = valueType == null
                                               ? string.Format("member {0}", name)
                                               : string.Format("member {0} mapped to type {1}", name,
                                                               memberType.Name);
                                iter.MoveNext();
                                object obj = OnStack(p, mappingStack,
                                                     (() =>
                                                      MapValueNode(iter, memberType, mappingStack, mappingAction)));
                                if (element.MemberType == MemberTypes.Field)
                                    (element as FieldInfo).SetValue(instance, obj);
                                else
                                    (element as PropertyInfo).SetValue(instance, obj, null);
                                ++num;
                            }
                        }
                    }
                    else
                        break;
                }
                if (mappingAction1 == MappingAction.Error && names.Count > 0)
                    ReportMissingMembers(valueType, names, mappingStack);
                return instance;
            }
            finally
            {
                mappingStack.Pop();
            }
        }

        private void AddCustomField(IEnumerator<Node> iter, MappingStack mappingStack, MappingAction mappingAction, string name,
                                     object instance)
        {
            Type valType;

            if (iter.Current is Base64Value || iter.Current is LongValue)
            {
                valType = typeof (long);
            }
            else if (iter.Current is BooleanValue)
            {
                valType = typeof (bool);
            }
            else if (iter.Current is DateTimeValue)
            {
                valType = typeof (DateTime);
            }
            else if (iter.Current is DoubleValue)
            {
                valType = typeof (double);
            }
            else if (iter.Current is IntValue)
            {
                valType = typeof (int);
            }
            else if (iter.Current is StringValue)
            {
                valType = typeof (string);
            }
            else return;

            object obj = OnStack(name, mappingStack, (() => MapValueNode(iter, valType, mappingStack, mappingAction)));
            ((Table) instance).SetCustomField(name, obj);
        }

        private object MapArray(IEnumerator<Node> iter, Type valType, MappingStack mappingStack,
                                MappingAction mappingAction, out Type mappedType)
        {
            mappedType = null;
            if (valType != null && !valType.IsArray && (valType != typeof (Array) && valType != typeof (object)))
            {
                throw new XmlRpcTypeMismatchException(mappingStack.MappingType + " contains array value where " +
                                                      XmlRpcTypeInfo.GetXmlRpcTypeString(valType) + " expected " +
                                                      StackDump(mappingStack));
            }
            if (valType != null)
            {
                if (XmlRpcTypeInfo.GetXmlRpcType(valType) == XmlRpcType.tMultiDimArray)
                {
                    (mappingStack).Push("array mapped to type " + valType.Name);
                    return MapMultiDimArray(iter, valType, mappingStack, mappingAction);
                }
                else
                    (mappingStack).Push("array mapped to type " + valType.Name);
            }
            else
                (mappingStack).Push("array");
            List<object> list = new List<object>();
            Type valType1 = DetermineArrayItemType(valType);
            bool flag = false;
            Type elementType = null;
            while (iter.MoveNext() && iter.Current is ValueNode)
            {
                (mappingStack).Push(string.Format("element {0}", list.Count));
                object obj = MapValueNode(iter, valType1, mappingStack, mappingAction);
                list.Add(obj);
                mappingStack.Pop();
            }
            foreach (object obj in list)
            {
                if (obj != null)
                {
                    if (!flag)
                    {
                        elementType = obj.GetType();
                        flag = true;
                    }
                    else if (elementType != obj.GetType())
                        elementType = null;
                }
            }
            object[] args = new object[1]
                            {
                                list.Count
                            };
            object obj1 = valType == null || valType == typeof (Array) || valType == typeof (object)
                              ? (elementType != null
                                     ? Array.CreateInstance(elementType, (int) args[0])
                                     : CreateArrayInstance(typeof (object[]), args))
                              : CreateArrayInstance(valType, args);
            for (int index = 0; index < list.Count; ++index)
                ((Array) obj1).SetValue(list[index], index);
            mappingStack.Pop();
            return obj1;
        }

        private static Type DetermineArrayItemType(Type valType)
        {
            return valType == null || valType == typeof (Array) || valType == typeof (object)
                       ? typeof (object)
                       : valType.GetElementType();
        }

        private void CheckImplictString(Type valType, MappingStack mappingStack)
        {
            if (valType == null || valType == typeof (string) || valType.IsEnum)
                return;
            throw new XmlRpcTypeMismatchException(mappingStack.MappingType + " contains implicit string value where " +
                                                  XmlRpcTypeInfo.GetXmlRpcTypeString(valType) + " expected " +
                                                  StackDump(mappingStack));
        }

        private object MapMultiDimArray(IEnumerator<Node> iter, Type valueType, MappingStack mappingStack,
                                        MappingAction mappingAction)
        {
            Type elementType = valueType.GetElementType();
            int arrayRank = valueType.GetArrayRank();
            var elements = new List<object>();
            var dimLengths = new int[arrayRank];
            dimLengths.Initialize();
            MapMultiDimElements(iter, arrayRank, 0, elementType, elements, dimLengths, mappingStack, mappingAction);
            var args = new object[dimLengths.Length];
            for (int index = 0; index < dimLengths.Length; ++index)
                args[index] = dimLengths[index];
            var array = (Array) CreateArrayInstance(valueType, args);
            int length = array.Length;
            for (int index1 = 0; index1 < length; ++index1)
            {
                var numArray = new int[dimLengths.Length];
                int num = 1;
                for (int index2 = numArray.Length - 1; index2 >= 0; --index2)
                {
                    numArray[index2] = index1/num%dimLengths[index2];
                    num *= dimLengths[index2];
                }
                array.SetValue(elements[index1], numArray);
            }
            return array;
        }

        private void MapMultiDimElements(IEnumerator<Node> iter, int rank, int curRank, Type elemType,
                                         List<object> elements, int[] dimLengths, MappingStack mappingStack,
                                         MappingAction mappingAction)
        {
            int num = 0;
            if (curRank < rank - 1)
            {
                while (iter.MoveNext() && iter.Current is ArrayValue)
                {
                    ++num;
                    MapMultiDimElements(iter, rank, curRank + 1, elemType, elements, dimLengths, mappingStack,
                                        mappingAction);
                }
            }
            else
            {
                while (iter.MoveNext() && iter.Current is ValueNode)
                {
                    ++num;
                    object obj = MapValueNode(iter, elemType, mappingStack, mappingAction);
                    elements.Add(obj);
                }
            }
            dimLengths[curRank] = num;
        }

        public object ParseValueElement(XmlReader rdr, Type valType, MappingStack mappingStack,
                                        MappingAction mappingAction)
        {
            IEnumerator<Node> enumerator = new XmlRpcParser().ParseValue(rdr).GetEnumerator();
            enumerator.MoveNext();
            return MapValueNode(enumerator, valType, mappingStack, mappingAction);
        }

        private static void CreateFieldNamesMap(Type valueType, List<string> names)
        {
            foreach (FieldInfo fieldInfo in valueType.GetFields())
            {
                if (!Attribute.IsDefined(fieldInfo, typeof (NonSerializedAttribute)))
                    names.Add(fieldInfo.Name);
            }
            foreach (PropertyInfo propertyInfo in valueType.GetProperties())
            {
                if (!Attribute.IsDefined(propertyInfo, typeof (NonSerializedAttribute)))
                    names.Add(propertyInfo.Name);
            }
        }

        private void CheckExpectedType(Type expectedType, Type actualType, MappingStack mappingStack)
        {
            if (expectedType != null && expectedType.IsEnum)
            {
                var array1 = new[]
                             {
                                 typeof (byte),
                                 typeof (sbyte),
                                 typeof (short),
                                 typeof (ushort),
                                 typeof (int)
                             };
                var array2 = new[]
                             {
                                 typeof (uint),
                                 typeof (long)
                             };
                Type underlyingType = Enum.GetUnderlyingType(expectedType);
                if (Array.IndexOf(array1, underlyingType) >= 0)
                    expectedType = typeof (int);
                else if (Array.IndexOf(array2, underlyingType) >= 0)
                    expectedType = typeof (long);
                else
                    throw new XmlRpcInvalidEnumValue(mappingStack.MappingType + " contains " +
                                                     XmlRpcTypeInfo.GetXmlRpcTypeString(actualType) +
                                                     " which cannot be mapped to  " +
                                                     XmlRpcTypeInfo.GetXmlRpcTypeString(expectedType) + " " +
                                                     StackDump(mappingStack));
            }
            if (expectedType == null || expectedType == typeof (object) ||
                (expectedType == actualType || !actualType.IsValueType))
                return;
            if (expectedType == typeof (Nullable<>).MakeGenericType(new Type[]
                                                                    {
                                                                        actualType
                                                                    }))
                return;
            throw new XmlRpcTypeMismatchException(mappingStack.MappingType + " contains " +
                                                  XmlRpcTypeInfo.GetXmlRpcTypeString(actualType) + " value where " +
                                                  XmlRpcTypeInfo.GetXmlRpcTypeString(expectedType) + " expected " +
                                                  StackDump(mappingStack));
        }

        private T OnStack<T>(string p, MappingStack mappingStack, Func<T> func)
        {
            (mappingStack).Push(p);
            try
            {
                return func();
            }
            finally
            {
                mappingStack.Pop();
            }
        }

        private void ReportMissingMembers(Type valueType, IEnumerable<string> names, MappingStack mappingStack)
        {
            var stringBuilder = new StringBuilder();
            int num = 0;
            string str1 = "";
            foreach (string memberName in names)
            {
                if (MemberMappingAction(valueType, memberName, MappingAction.Error) == MappingAction.Error)
                {
                    stringBuilder.Append(str1);
                    stringBuilder.Append(memberName);
                    str1 = " ";
                    ++num;
                }
            }
            if (num <= 0)
                return;
            string str2 = "";
            if (num > 1)
                str2 = "s";
            throw new XmlRpcTypeMismatchException(mappingStack.MappingType +
                                                  " contains struct value with missing non-optional member" + str2 +
                                                  ": " + (stringBuilder) + " " + StackDump(mappingStack));
        }

        private string GetStructName(Type ValueType, string XmlRpcName)
        {
            if (ValueType == null)
                return null;
            foreach (FieldInfo fieldInfo in ValueType.GetFields())
            {
                Attribute customAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof (XmlRpcMemberAttribute));
                if (customAttribute != null && customAttribute is XmlRpcMemberAttribute &&
                    ((XmlRpcMemberAttribute) customAttribute).Member == XmlRpcName)
                    return fieldInfo.Name;
            }
            foreach (PropertyInfo propertyInfo in ValueType.GetProperties())
            {
                Attribute customAttribute = Attribute.GetCustomAttribute(propertyInfo, typeof (XmlRpcMemberAttribute));
                if (customAttribute != null && customAttribute is XmlRpcMemberAttribute &&
                    ((XmlRpcMemberAttribute) customAttribute).Member == XmlRpcName)
                    return propertyInfo.Name;
            }
            return null;
        }

        private MappingAction StructMappingAction(Type type, MappingAction currentAction)
        {
            if (type == null)
                return currentAction;
            Attribute customAttribute = Attribute.GetCustomAttribute(type, typeof (XmlRpcMissingMappingAttribute));
            if (customAttribute != null)
                return ((XmlRpcMissingMappingAttribute) customAttribute).Action;
            else
                return currentAction;
        }

        private MappingAction MemberMappingAction(Type type, string memberName, MappingAction currentAction)
        {
            if (type == null)
                return currentAction;
            FieldInfo field = type.GetField(memberName);
            Attribute attribute = field == null
                                      ? Attribute.GetCustomAttribute(type.GetProperty(memberName),
                                                                     typeof (XmlRpcMissingMappingAttribute))
                                      : Attribute.GetCustomAttribute(field, typeof (XmlRpcMissingMappingAttribute));
            if (attribute != null)
                return ((XmlRpcMissingMappingAttribute) attribute).Action;
            else
                return currentAction;
        }

        private string StackDump(MappingStack mappingStack)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in mappingStack)
            {
                stringBuilder.Insert(0, str);
                stringBuilder.Insert(0, " : ");
            }
            stringBuilder.Insert(0, mappingStack.MappingType);
            stringBuilder.Insert(0, "[");
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }

        private object CreateArrayInstance(Type type, object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        private bool IsStructParamsMethod(MethodInfo mi)
        {
            if (mi == null)
                return false;
            bool flag = false;
            Attribute customAttribute = Attribute.GetCustomAttribute(mi, typeof (XmlRpcMethodAttribute));
            if (customAttribute != null)
                flag = ((XmlRpcMethodAttribute) customAttribute).StructParams;
            return flag;
        }

        private delegate T Func<T>();
    }
}