using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace CefSharp.DevTools
{
	// Token: 0x0200011D RID: 285
	[DataContract]
	public abstract class DevToolsDomainEntityBase
	{
		// Token: 0x06000860 RID: 2144 RVA: 0x0000D66C File Offset: 0x0000B86C
		internal static object StringToEnum(Type enumType, string input)
		{
			if (!enumType.IsArray)
			{
				if (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					if (string.IsNullOrEmpty(input))
					{
						return null;
					}
					enumType = Nullable.GetUnderlyingType(enumType);
				}
				return DevToolsDomainEntityBase.StringToEnumInternal(enumType, input);
			}
			if (string.IsNullOrEmpty(input) || input == "[]" || input == "[ ]")
			{
				return null;
			}
			string[] array = input.Substring(1, input.Length - 2).Split(new char[]
			{
				','
			});
			Array array2 = Array.CreateInstance(enumType.GetElementType(), array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				string input2 = array[i].Trim(new char[]
				{
					'\r',
					'\n',
					'"',
					' '
				});
				object value = DevToolsDomainEntityBase.StringToEnumInternal(enumType.GetElementType(), input2);
				array2.SetValue(value, i);
			}
			return array2;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0000D750 File Offset: 0x0000B950
		private static object StringToEnumInternal(Type enumType, string input)
		{
			foreach (string text in Enum.GetNames(enumType))
			{
				EnumMemberAttribute enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(text).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single<EnumMemberAttribute>();
				if (enumMemberAttribute.Value == input)
				{
					return Enum.Parse(enumType, text);
				}
			}
			return Enum.GetValues(enumType).GetValue(0);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		internal static string EnumToString(Enum e)
		{
			MemberInfo element = e.GetType().GetMember(e.ToString()).FirstOrDefault<MemberInfo>();
			EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(element, typeof(EnumMemberAttribute), false);
			return enumMemberAttribute.Value;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0000D800 File Offset: 0x0000BA00
		internal static string EnumToString(Array enumArray)
		{
			string text = "[";
			foreach (object obj in enumArray)
			{
				MemberInfo element = obj.GetType().GetMember(obj.ToString()).FirstOrDefault<MemberInfo>();
				EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)Attribute.GetCustomAttribute(element, typeof(EnumMemberAttribute), false);
				text = text + enumMemberAttribute.Value + ",";
			}
			text = text + text.Substring(0, text.Length - 1) + "]";
			return text;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0000D8B0 File Offset: 0x0000BAB0
		public IDictionary<string, object> ToDictionary()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			PropertyInfo[] properties = base.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (PropertyInfo propertyInfo in properties)
			{
				DataMemberAttribute dataMemberAttribute = (DataMemberAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DataMemberAttribute), false);
				if (dataMemberAttribute != null)
				{
					string name = dataMemberAttribute.Name;
					bool isRequired = dataMemberAttribute.IsRequired;
					object obj = propertyInfo.GetValue(this);
					if (isRequired && obj == null)
					{
						throw new DevToolsClientException(propertyInfo.Name + " is required");
					}
					if (obj != null)
					{
						Type type = obj.GetType();
						if (typeof(DevToolsDomainEntityBase).IsAssignableFrom(type))
						{
							obj = ((DevToolsDomainEntityBase)obj).ToDictionary();
						}
						else if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>) && typeof(DevToolsDomainEntityBase).IsAssignableFrom(propertyInfo.PropertyType.GetGenericArguments()[0]))
						{
							List<IDictionary<string, object>> list = new List<IDictionary<string, object>>();
							foreach (object obj2 in ((IEnumerable)obj))
							{
								list.Add(((DevToolsDomainEntityBase)obj2).ToDictionary());
							}
							obj = list;
						}
						dictionary.Add(name, obj);
					}
				}
			}
			return dictionary;
		}
	}
}
