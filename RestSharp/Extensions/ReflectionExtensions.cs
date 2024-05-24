using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x02000048 RID: 72
	[NullableContext(1)]
	[Nullable(0)]
	public static class ReflectionExtensions
	{
		// Token: 0x060004D0 RID: 1232 RVA: 0x0000BB17 File Offset: 0x00009D17
		public static T GetAttribute<[Nullable(0)] T>(this MemberInfo prop) where T : Attribute
		{
			return Attribute.GetCustomAttribute(prop, typeof(T)) as T;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x0000BB33 File Offset: 0x00009D33
		public static T GetAttribute<[Nullable(0)] T>(this Type type) where T : Attribute
		{
			return Attribute.GetCustomAttribute(type, typeof(T)) as T;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x0000BB50 File Offset: 0x00009D50
		public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
		{
			while (toCheck != null && toCheck != typeof(object))
			{
				Type right = toCheck.GetTypeInfo().IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
				if (generic == right)
				{
					return true;
				}
				toCheck = toCheck.GetTypeInfo().BaseType;
			}
			return false;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x0000BBAA File Offset: 0x00009DAA
		internal static object ChangeType(this object source, Type newType)
		{
			return Convert.ChangeType(source, newType);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x0000BBB4 File Offset: 0x00009DB4
		public static object FindEnumValue(this Type type, string value, CultureInfo culture)
		{
			StringComparer caseInsensitiveComparer = StringComparer.Create(culture, true);
			Enum @enum = Enum.GetValues(type).Cast<Enum>().FirstOrDefault((Enum v) => v.ToString().GetNameVariants(culture).Contains(value, caseInsensitiveComparer));
			if (@enum != null)
			{
				return @enum;
			}
			object obj = Convert.ChangeType(value, Enum.GetUnderlyingType(type), culture);
			if (obj != null && Enum.IsDefined(type, obj))
			{
				@enum = (Enum)Enum.ToObject(type, obj);
			}
			return @enum;
		}
	}
}
