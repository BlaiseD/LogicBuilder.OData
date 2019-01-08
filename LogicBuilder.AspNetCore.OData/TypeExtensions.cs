using System;
using System.Linq;
using System.Reflection;

namespace LogicBuilder.AspNetCore.OData
{
    internal static class TypeExtensions
    {
        /// <summary>
        /// Get MemberInfo
        /// </summary>
        /// <param name="parentType"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo(this Type parentType, string memberName)
        {
            MemberInfo mInfo = parentType.GetMember(memberName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase).FirstOrDefault();
            if (mInfo == null)
                throw new ArgumentException(string.Format(Properties.Resources.memberDoesNotExistFormat, memberName, parentType.FullName));

            return mInfo;
        }

        /// <summary>
        /// Is Enumerable
        /// </summary>
        /// <param name="memberType"></param>
        /// <returns></returns>
        public static bool IsEnumerable(this Type memberType)
            => memberType.IsGenericType && typeof(System.Collections.IEnumerable).IsAssignableFrom(memberType);

        /// <summary>
        /// Get Member Type
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static Type GetMemberType(this MemberInfo memberInfo)
        {
            switch (memberInfo)
            {
                case MethodInfo mInfo:
                    return mInfo.ReturnType;
                case PropertyInfo pInfo:
                    return pInfo.PropertyType;
                case FieldInfo fInfo:
                    return fInfo.FieldType;
                case null:
                    throw new ArgumentNullException(nameof(memberInfo));
                default:
                    throw new ArgumentOutOfRangeException(nameof(memberInfo));
            }
        }
    }
}
