using System;
using System.ComponentModel;

namespace EasyMaticaSrl.Utilities.Helpers
{
    /// <summary>
    /// This class contains some methods for to help deal with enums.
    /// </summary>
    public static class EnumHelper
    {
        public static string ToDescription(this System.Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);

            if (!type.IsEnum)
            {
                throw new InvalidOperationException();
            }

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new System.ArgumentException("Not found.", "description");
            // or return default(T);
        }

    }
}
