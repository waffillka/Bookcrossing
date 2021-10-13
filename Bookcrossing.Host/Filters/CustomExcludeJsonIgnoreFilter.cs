﻿using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace Bookcrossing.Host.Filters
{
    internal static class StringExtensions
    {
        internal static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }

    public class CustomExcludeJsonIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
        {
            if (schema.Properties.Count == 0)
            {
                return;
            }

            const BindingFlags bindingFlags = BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Instance;
            var memberList = schemaFilterContext.Type
                                                .GetFields(bindingFlags).Cast<MemberInfo>()
                                                .Concat(schemaFilterContext.Type
                                                                           .GetProperties(bindingFlags));

            var excludedList = memberList.Where(m =>
                                                    m.GetCustomAttribute<JsonIgnoreAttribute>()
                                                    != null)
                                         .Select(m =>
                                                     (m.GetCustomAttribute<JsonPropertyAttribute>()
                                                      ?.PropertyName
                                                      ?? m.Name.ToCamelCase()));

            foreach (var excludedName in excludedList)
            {
                if (schema.Properties.ContainsKey(excludedName))
                {
                    schema.Properties.Remove(excludedName);
                }
            }
        }
    }
}
