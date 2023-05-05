using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thera.Enum
{
    public static class EHelper
    {
        public static string GetDescription(this System.Enum valorEnum)
        {
            return valorEnum.GetTypeAttribute<DescriptionAttribute>().Description;
        }

        private static T GetTypeAttribute<T>(this System.Enum valorEnum) where T : Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
