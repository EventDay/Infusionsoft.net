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

namespace InfusionSoft
{
    public class CustomFieldType
    {
        private CustomFieldType(string name, Type dataType)
        {
            Name = name;
            DataType = dataType.ToString();
        }

        public string Name { get; private set; }

        public string DataType { get; private set; }

        #region Nested type: Type

        public class Type
        {
            public static readonly Type Currency = new Type("Currency");
            public static readonly Type Date = new Type("Date");
            public static readonly Type DateTime = new Type("Date/Time");
            public static readonly Type DayOfWeek = new Type("Day of Week");
            public static readonly Type Drilldown = new Type("Drilldown");
            public static readonly Type Email = new Type("Email");
            public static readonly Type Month = new Type("Month");
            public static readonly Type ListBox = new Type("List Box");
            public static readonly Type Name = new Type("Name");
            public static readonly Type WholeNumber = new Type("Whole Number");
            public static readonly Type DecimalNumber = new Type("Decimal Number");
            public static readonly Type Percent = new Type("Percent");
            public static readonly Type PhoneNumber = new Type("Phone Number");
            public static readonly Type Radio = new Type("Radio");
            public static readonly Type DropDown = new Type("Drop-down");
            public static readonly Type SocialSecurityNumber = new Type("Social Security Number");
            public static readonly Type State = new Type("State");
            public static readonly Type Text = new Type("Text");
            public static readonly Type TextArea = new Type("Text Area");
            public static readonly Type User = new Type("User");
            public static readonly Type Website = new Type("Website");
            public static readonly Type Year = new Type("Year");
            public static readonly Type YesNo = new Type("Yes/No");
            private readonly string _name;

            private Type(string name)
            {
                _name = name;
            }

            public override string ToString()
            {
                return _name;
            }
        }

        #endregion

        public static CustomFieldType Person(Type dataType)
        {
            return new CustomFieldType("Person", dataType);
        }

        public static CustomFieldType Company(Type dataType)
        {
            return new CustomFieldType("Company", dataType);
        }

        public static CustomFieldType Task(Type dataType)
        {
            return new CustomFieldType("Task/Appt/Note", dataType);
        }

        public static CustomFieldType Appointment(Type dataType)
        {
            return new CustomFieldType("Task/Appt/Note", dataType);
        }

        public static CustomFieldType Note(Type dataType)
        {
            return new CustomFieldType("Task/Appt/Note", dataType);
        }

        public static CustomFieldType Order(Type dataType)
        {
            return new CustomFieldType("Order", dataType);
        }

        public static CustomFieldType Subscription(Type dataType)
        {
            return new CustomFieldType("Subscription", dataType);
        }

        public static CustomFieldType Opportunity(Type dataType)
        {
            return new CustomFieldType("Opportunity", dataType);
        }
    }
}