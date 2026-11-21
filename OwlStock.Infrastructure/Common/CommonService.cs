using System.ComponentModel;
using System.Reflection;

namespace OwlStock.Infrastructure.Common
{
    internal static class CommonService
    {
        internal static string GetEnumDescription(this Enum e)
        {
            var descriptionAttribute = e.GetType().GetMember(e.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0]
                as DescriptionAttribute;

            return descriptionAttribute.Description;
        }
    }
}
