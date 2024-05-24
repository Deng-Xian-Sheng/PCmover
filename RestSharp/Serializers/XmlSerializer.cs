using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using RestSharp.Extensions;
using RestSharp.Serialization;
using RestSharp.Serialization.Xml;

namespace RestSharp.Serializers
{
	// Token: 0x02000036 RID: 54
	[NullableContext(1)]
	[Nullable(0)]
	public class XmlSerializer : IXmlSerializer, ISerializer, IWithRootElement
	{
		// Token: 0x06000454 RID: 1108 RVA: 0x000098B9 File Offset: 0x00007AB9
		public XmlSerializer()
		{
			this.ContentType = "application/xml";
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x000098CC File Offset: 0x00007ACC
		public XmlSerializer(string @namespace) : this()
		{
			this.Namespace = @namespace;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x000098DC File Offset: 0x00007ADC
		public string Serialize(object obj)
		{
			XDocument xdocument = new XDocument();
			Type type = obj.GetType();
			string text = type.Name;
			SerializeAsAttribute attribute = type.GetAttribute<SerializeAsAttribute>();
			if (attribute != null)
			{
				text = attribute.TransformName(attribute.Name ?? text);
			}
			XElement xelement = new XElement(text.AsNamespaced(this.Namespace));
			IList list = obj as IList;
			if (list != null)
			{
				string text2 = "";
				using (IEnumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj2 = enumerator.Current;
						Type type2 = obj2.GetType();
						SerializeAsAttribute attribute2 = type2.GetAttribute<SerializeAsAttribute>();
						if (attribute2 != null)
						{
							text2 = attribute2.TransformName(attribute2.Name ?? text);
						}
						if (text2 == "")
						{
							text2 = type2.Name;
						}
						XElement xelement2 = new XElement(text2.AsNamespaced(this.Namespace));
						this.Map(xelement2, obj2);
						xelement.Add(xelement2);
					}
					goto IL_FA;
				}
			}
			this.Map(xelement, obj);
			IL_FA:
			if (this.RootElement.HasValue())
			{
				XElement content = new XElement(this.RootElement.AsNamespaced(this.Namespace), xelement);
				xdocument.Add(content);
			}
			else
			{
				xdocument.Add(xelement);
			}
			return xdocument.ToString();
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x00009A30 File Offset: 0x00007C30
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x00009A38 File Offset: 0x00007C38
		public string RootElement { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x00009A41 File Offset: 0x00007C41
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x00009A49 File Offset: 0x00007C49
		public string Namespace { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x00009A52 File Offset: 0x00007C52
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x00009A5A File Offset: 0x00007C5A
		public string DateFormat { get; set; }

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00009A63 File Offset: 0x00007C63
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x00009A6B File Offset: 0x00007C6B
		public string ContentType { get; set; }

		// Token: 0x0600045F RID: 1119 RVA: 0x00009A74 File Offset: 0x00007C74
		private void Map(XContainer root, object obj)
		{
			Type type = obj.GetType();
			IEnumerable<PropertyInfo> enumerable = from t in (from p in type.GetProperties()
			select new
			{
				p = p,
				indexAttribute = p.GetAttribute<SerializeAsAttribute>()
			} into t
			where t.p.CanRead && t.p.CanWrite
			select t).OrderBy(delegate(t)
			{
				SerializeAsAttribute indexAttribute = t.indexAttribute;
				if (indexAttribute == null)
				{
					return int.MaxValue;
				}
				return indexAttribute.Index;
			})
			select t.p;
			SerializeAsAttribute attribute = type.GetAttribute<SerializeAsAttribute>();
			bool flag = false;
			foreach (PropertyInfo propertyInfo in enumerable)
			{
				string text = propertyInfo.Name;
				object value = propertyInfo.GetValue(obj, null);
				if (value != null)
				{
					Type propertyType = propertyInfo.PropertyType;
					bool flag2 = false;
					bool flag3 = false;
					SerializeAsAttribute attribute2 = propertyInfo.GetAttribute<SerializeAsAttribute>();
					if (attribute2 != null)
					{
						text = (attribute2.Name.HasValue() ? attribute2.Name : text);
						text = attribute2.TransformName(text);
						flag2 = attribute2.Attribute;
						flag3 = attribute2.Content;
						if (flag && flag3)
						{
							throw new ArgumentException("Class cannot have two properties marked with SerializeAs(Content = true) attribute.");
						}
						flag = (flag || flag3);
					}
					else if (attribute != null)
					{
						text = attribute.TransformName(text);
					}
					XElement xelement = new XElement(text.AsNamespaced(this.Namespace));
					if (propertyType.GetTypeInfo().IsPrimitive || propertyType.GetTypeInfo().IsValueType || propertyType == typeof(string))
					{
						string serializedValue = this.GetSerializedValue(value);
						if (flag2)
						{
							root.Add(new XAttribute(text, serializedValue));
							continue;
						}
						if (flag3)
						{
							root.Add(new XText(serializedValue));
							continue;
						}
						xelement.Value = serializedValue;
					}
					else
					{
						IList list = value as IList;
						if (list != null)
						{
							foreach (object obj2 in list)
							{
								Type type2 = obj2.GetType();
								SerializeAsAttribute attribute3 = type2.GetAttribute<SerializeAsAttribute>();
								XElement xelement2 = new XElement(((attribute3 != null && attribute3.Name.HasValue()) ? attribute3.Name : type2.Name).AsNamespaced(this.Namespace));
								this.Map(xelement2, obj2);
								if (flag3)
								{
									root.Add(xelement2);
								}
								else
								{
									xelement.Add(xelement2);
								}
							}
							if (flag3)
							{
								continue;
							}
						}
						else
						{
							this.Map(xelement, value);
						}
					}
					root.Add(xelement);
				}
			}
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00009D6C File Offset: 0x00007F6C
		private string GetSerializedValue(object obj)
		{
			object obj2 = obj;
			if (obj is DateTime)
			{
				DateTime dateTime = (DateTime)obj;
				if (this.DateFormat.HasValue())
				{
					obj2 = dateTime.ToString(this.DateFormat, CultureInfo.InvariantCulture);
				}
			}
			else if (obj is bool)
			{
				obj2 = ((bool)obj).ToString().ToLowerInvariant();
			}
			if (!XmlSerializer.IsNumeric(obj))
			{
				return obj2.ToString();
			}
			return XmlSerializer.SerializeNumber(obj);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00009DE4 File Offset: 0x00007FE4
		private static string SerializeNumber(object number)
		{
			if (number is long)
			{
				return ((long)number).ToString(CultureInfo.InvariantCulture);
			}
			if (number is ulong)
			{
				return ((ulong)number).ToString(CultureInfo.InvariantCulture);
			}
			if (number is int)
			{
				return ((int)number).ToString(CultureInfo.InvariantCulture);
			}
			if (number is uint)
			{
				return ((uint)number).ToString(CultureInfo.InvariantCulture);
			}
			if (number is decimal)
			{
				return ((decimal)number).ToString(CultureInfo.InvariantCulture);
			}
			if (number is float)
			{
				return ((float)number).ToString(CultureInfo.InvariantCulture);
			}
			return Convert.ToDouble(number, CultureInfo.InvariantCulture).ToString("r", CultureInfo.InvariantCulture);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00009EC8 File Offset: 0x000080C8
		private static bool IsNumeric(object value)
		{
			return value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong || value is float || value is double || value is decimal;
		}
	}
}
