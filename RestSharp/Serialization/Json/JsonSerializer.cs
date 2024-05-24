using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using RestSharp.Deserializers;
using RestSharp.Extensions;
using RestSharp.Serializers;

namespace RestSharp.Serialization.Json
{
	// Token: 0x02000044 RID: 68
	[NullableContext(1)]
	[Nullable(0)]
	public class JsonSerializer : IRestSerializer, ISerializer, IDeserializer, IWithRootElement
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000B1C3 File Offset: 0x000093C3
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0000B1CB File Offset: 0x000093CB
		public string DateFormat { get; set; }

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000B1D4 File Offset: 0x000093D4
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0000B1DC File Offset: 0x000093DC
		public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

		// Token: 0x060004BA RID: 1210 RVA: 0x0000B1E8 File Offset: 0x000093E8
		public string Serialize(object obj)
		{
			string result;
			if (!JsonSerializer.IsSerializedString(obj, out result))
			{
				return SimpleJson.SerializeObject(obj);
			}
			return result;
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x0000B207 File Offset: 0x00009407
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x0000B20F File Offset: 0x0000940F
		public string ContentType { get; set; } = "application/json";

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000B218 File Offset: 0x00009418
		public string[] SupportedContentTypes { get; } = RestSharp.Serialization.ContentType.JsonAccept;

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000B220 File Offset: 0x00009420
		public DataFormat DataFormat { get; }

		// Token: 0x060004BF RID: 1215 RVA: 0x0000B228 File Offset: 0x00009428
		public string Serialize(Parameter parameter)
		{
			return this.Serialize(parameter.Value);
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000B238 File Offset: 0x00009438
		public T Deserialize<[Nullable(2)] T>(IRestResponse response)
		{
			object value = this.FindRoot(response.Content);
			return (T)((object)this.ConvertValue(typeof(T).GetTypeInfo(), value));
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000B26D File Offset: 0x0000946D
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x0000B275 File Offset: 0x00009475
		public string RootElement { get; set; }

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000B280 File Offset: 0x00009480
		private static bool IsSerializedString(object obj, out string serializedString)
		{
			string text = obj as string;
			if (text != null)
			{
				string text2 = text.Trim();
				if ((text2.StartsWith("{") && text2.EndsWith("}")) || (text2.StartsWith("[{") && text2.EndsWith("}]")))
				{
					serializedString = text;
					return true;
				}
			}
			serializedString = null;
			return false;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000B2DC File Offset: 0x000094DC
		private object FindRoot(string content)
		{
			object obj = SimpleJson.DeserializeObject(content);
			if (!this.RootElement.HasValue())
			{
				return obj;
			}
			IDictionary<string, object> dictionary = obj as IDictionary<string, object>;
			if (dictionary == null)
			{
				return obj;
			}
			object result;
			if (!dictionary.TryGetValue(this.RootElement, out result))
			{
				return obj;
			}
			return result;
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000B320 File Offset: 0x00009520
		private object Map(object target, IDictionary<string, object> data)
		{
			foreach (PropertyInfo propertyInfo in (from p in target.GetType().GetTypeInfo().GetProperties()
			where p.CanWrite
			select p).ToList<PropertyInfo>())
			{
				object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(DeserializeAsAttribute), false);
				string name;
				if (customAttributes.Any<object>())
				{
					name = ((DeserializeAsAttribute)customAttributes.First<object>()).Name;
				}
				else
				{
					name = propertyInfo.Name;
				}
				object obj;
				if (!data.TryGetValue(name, out obj))
				{
					string[] array = name.Split(new char[]
					{
						'.'
					});
					IDictionary<string, object> dictionary = data;
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i].GetNameVariants(this.Culture).Distinct<string>().FirstOrDefault(new Func<string, bool>(dictionary.ContainsKey));
						if (text == null)
						{
							break;
						}
						if (i == array.Length - 1)
						{
							obj = dictionary[text];
						}
						else
						{
							dictionary = (IDictionary<string, object>)dictionary[text];
						}
					}
				}
				if (obj != null)
				{
					TypeInfo typeInfo = propertyInfo.PropertyType.GetTypeInfo();
					propertyInfo.SetValue(target, this.ConvertValue(typeInfo, obj), null);
				}
			}
			return target;
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x0000B488 File Offset: 0x00009688
		private IDictionary BuildDictionary(Type type, object parent)
		{
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
			Type type2 = type.GetTypeInfo().GetGenericArguments()[0];
			Type type3 = type.GetTypeInfo().GetGenericArguments()[1];
			foreach (KeyValuePair<string, object> keyValuePair in ((IDictionary<string, object>)parent))
			{
				object key = (type2 != typeof(string)) ? Convert.ChangeType(keyValuePair.Key, type2, CultureInfo.InvariantCulture) : keyValuePair.Key;
				object value = (type3.GetTypeInfo().IsGenericType && type3.GetTypeInfo().GetGenericTypeDefinition() == typeof(List<>)) ? this.BuildList(type3, keyValuePair.Value) : this.ConvertValue(type3.GetTypeInfo(), keyValuePair.Value);
				dictionary.Add(key, value);
			}
			return dictionary;
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x0000B588 File Offset: 0x00009788
		private IList BuildList(Type type, object parent)
		{
			IList list = (IList)Activator.CreateInstance(type);
			Type type2 = type.GetTypeInfo().GetInterfaces().First((Type x) => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)).GetTypeInfo().GetGenericArguments()[0];
			IList list2 = parent as IList;
			if (list2 != null)
			{
				using (IEnumerator enumerator = list2.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (type2.GetTypeInfo().IsPrimitive)
						{
							object value = this.ConvertValue(type2.GetTypeInfo(), obj);
							list.Add(value);
						}
						else if (type2 == typeof(string))
						{
							if (obj == null)
							{
								list.Add(null);
							}
							else
							{
								list.Add(obj.ToString());
							}
						}
						else if (obj == null)
						{
							list.Add(null);
						}
						else
						{
							object value2 = this.ConvertValue(type2.GetTypeInfo(), obj);
							list.Add(value2);
						}
					}
					return list;
				}
			}
			list.Add(this.ConvertValue(type2.GetTypeInfo(), parent));
			return list;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0000B6C4 File Offset: 0x000098C4
		private object ConvertValue(TypeInfo typeInfo, object value)
		{
			string text = Convert.ToString(value, this.Culture);
			if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				if (text.IsEmpty())
				{
					return null;
				}
				typeInfo = typeInfo.GetGenericArguments()[0].GetTypeInfo();
			}
			if (typeInfo.AsType() == typeof(object))
			{
				if (value == null)
				{
					return null;
				}
				typeInfo = value.GetType().GetTypeInfo();
			}
			Type type = typeInfo.AsType();
			if (typeInfo.IsPrimitive)
			{
				return value.ChangeType(type);
			}
			if (typeInfo.IsEnum)
			{
				return type.FindEnumValue(text, this.Culture);
			}
			if (type == typeof(Uri))
			{
				return new Uri(text, UriKind.RelativeOrAbsolute);
			}
			if (type == typeof(string))
			{
				return text;
			}
			if (type == typeof(DateTime) || type == typeof(DateTimeOffset))
			{
				DateTime dateTime;
				if (this.DateFormat.HasValue())
				{
					dateTime = DateTime.ParseExact(text, this.DateFormat, this.Culture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
				}
				else
				{
					dateTime = text.ParseJsonDate(this.Culture);
				}
				if (type == typeof(DateTime))
				{
					return dateTime;
				}
				if (type == typeof(DateTimeOffset))
				{
					return dateTime;
				}
				return null;
			}
			else if (type == typeof(decimal))
			{
				if (value is double)
				{
					double value2 = (double)value;
					return (decimal)value2;
				}
				return text.Contains("e") ? decimal.Parse(text, NumberStyles.Float, this.Culture) : decimal.Parse(text, this.Culture);
			}
			else
			{
				if (type == typeof(Guid))
				{
					return string.IsNullOrEmpty(text) ? Guid.Empty : new Guid(text);
				}
				if (type == typeof(TimeSpan))
				{
					TimeSpan timeSpan;
					return TimeSpan.TryParse(text, out timeSpan) ? timeSpan : XmlConvert.ToTimeSpan(text);
				}
				if (type.GetTypeInfo().IsGenericType)
				{
					Type genericTypeDefinition = type.GetGenericTypeDefinition();
					if (genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(IList<>))
					{
						Type type2 = typeInfo.GetGenericArguments()[0];
						Type type3 = typeof(List<>).MakeGenericType(new Type[]
						{
							type2
						});
						return this.BuildList(type3, value);
					}
					if (genericTypeDefinition == typeof(List<>))
					{
						return this.BuildList(type, value);
					}
					if (genericTypeDefinition == typeof(Dictionary<, >))
					{
						return this.BuildDictionary(type, value);
					}
					return this.CreateAndMap(type, value);
				}
				else
				{
					if (type.IsSubclassOfRawGeneric(typeof(List<>)))
					{
						return this.BuildList(type, value);
					}
					if (type == typeof(JsonObject))
					{
						return this.BuildDictionary(typeof(Dictionary<string, object>), value);
					}
					return this.CreateAndMap(type, value);
				}
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x0000B9DC File Offset: 0x00009BDC
		private object CreateAndMap(Type type, object element)
		{
			object target = Activator.CreateInstance(type);
			return this.Map(target, (IDictionary<string, object>)element);
		}
	}
}
