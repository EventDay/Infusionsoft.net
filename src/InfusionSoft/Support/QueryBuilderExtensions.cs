using System;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc;
using InfusionSoft.Tables;

namespace InfusionSoft
{
    internal static class QueryBuilderExtensions
    {
        private static Dictionary<Type, Dictionary<string, string>> _columnNames;
        private static Dictionary<Type, Dictionary<string, string>> ColumnNames
        {
            get
            {
                return _columnNames ?? (_columnNames = new Dictionary<Type, Dictionary<string, string>>());
            }
        }
        public static string GetColumnName<T>(this IQueryBuilder<T> builder, string propertyName) where T : ITable
        {
            if (!ColumnNames.ContainsKey(typeof(T)))
            {
                ColumnNames[typeof(T)] = new Dictionary<string, string>();
                typeof(T).GetProperties()
                    .Where(p => !p.Name.Equals("CustomFields") && !p.Name.EndsWith("Comparer"))
                    .ToList()
                    .ForEach(p =>
                    {
                        var attributes = p.GetCustomAttributes(typeof(XmlRpcMemberAttribute), false);
                        if (!attributes.Any())
                            return;
                        var attribute = attributes.Cast<XmlRpcMemberAttribute>().First();
                        if (!String.IsNullOrEmpty(attribute.Member) && attribute.Member != p.Name)
                        {
                            ColumnNames[typeof(T)].Add(p.Name, attribute.Member);
                        }
                    });
            }
            return ColumnNames[typeof(T)].ContainsKey(propertyName) ? _columnNames[typeof(T)][propertyName] : propertyName;
        }
    }
}
