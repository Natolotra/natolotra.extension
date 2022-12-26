using System.ComponentModel;
using System.Reflection;

namespace natolotra.extension.Enum
{
    /// <summary>
    /// Extension class for enums
    /// </summary>
    public static partial class EnumExtension
    {
        /// <summary>
        /// Extension method for enum to int
        /// </summary>
        /// <typeparam name="T">Enum type param</typeparam>
        /// <param name="soure">Enum source</param>
        /// <returns>Return int</returns>
        /// <exception cref="ArgumentException">Argument exception if the attribute is not enum</exception>
        public static int ToInt<T>(this T soure) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(EnumConst.ENUM_TO_INT_MESSAGE_ARG_EXC);

            return (int)(IConvertible)soure;
        }

        /// <summary>
        /// Extension method for enum to take description
        /// </summary>
        /// <typeparam name="T">Enum type param</typeparam>
        /// <param name="soure">Enum source</param>
        /// <returns>Return string</returns>
        /// <exception cref="ArgumentException">Argument exception if the argument is not enum</exception>
        /// <exception cref="ArgumentNullException">Argument exception if the argument is null</exception>
        public static string GetDesc<T>(this T soure) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException(EnumConst.ENUM_TO_INT_MESSAGE_ARG_EXC);

            string? sourceToStr = soure.ToString();

            if (sourceToStr == null)
                throw new ArgumentNullException(nameof(soure), EnumConst.ENUM_GET_DESC_MESSAGE_ARG_NUL_EXC);

            Type type = soure.GetType();
            FieldInfo? fieldInfo = type != null ? type.GetField(sourceToStr) : null;
            DescriptionAttribute? attribute = fieldInfo != null ? fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute : null;

            if (attribute != null)
            { return attribute.Description; }
            
            return sourceToStr;
        }

        /// <summary>
        /// Extension methode for string to take enum value
        /// </summary>
        /// <typeparam name="T">Enum type param</typeparam>
        /// <param name="source">String source</param>
        /// <returns>Return enum T</returns>
        /// <exception cref="ArgumentException">Argument exception if the argument is not enum</exception>
        /// <exception cref="ArgumentException">Argument exception if the argument is invalid value</exception>
        public static T GetEnumValue<T>(this string source) where T : struct, IConvertible
        {
            T outResult;
            var boolRes = System.Enum.TryParse<T>(source, true, out outResult);
            if (boolRes)
            { return outResult; }

            throw new ArgumentException(EnumConst.ENUM_GET_ENUM_VALUE_MESSAGE_ARG_VALUE_EXC);
        }
    }
}
