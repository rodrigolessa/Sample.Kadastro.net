using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Sample.Kadastro.Infraestrutura.Comuns.Extensions
{
    public static class TypeExtensions
    {
        public static string ObterDescricao(System.Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        public static IDictionary<object, string> ToDicionarioEnum(this System.Type enumType)
        {
            IDictionary<object, string> lista = new Dictionary<object, string>();

            foreach (System.Enum item in System.Enum.GetValues(enumType))
            {
                var valorEnum = item.GetType().GetField(item.ToString()).GetRawConstantValue();
                lista.Add(valorEnum, ObterDescricao(item));
            }

            return lista;
        }
    }
}
