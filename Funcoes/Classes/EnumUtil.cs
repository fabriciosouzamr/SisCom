using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Collections;

namespace Funcoes._Classes
{
    public static class EnumUtil
    {
        public static string GetDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static IList ToDataTable(Type myEnum = null)
        {
            return System.Enum.GetValues(myEnum)
                              .Cast<System.Enum>()
                              .Select(value => new {
                                        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                                        value
                                    })
                              .OrderBy(item => item.value)
                              .ToList();
        }
    }
}
