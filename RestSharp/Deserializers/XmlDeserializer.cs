using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using RestSharp.Extensions;
using RestSharp.Serialization;
using RestSharp.Serialization.Xml;

namespace RestSharp.Deserializers
{
	// Token: 0x0200003A RID: 58
	[NullableContext(1)]
	[Nullable(0)]
	public class XmlDeserializer : IXmlDeserializer, IDeserializer, IWithRootElement
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x0000A04F File Offset: 0x0000824F
		public XmlDeserializer()
		{
			this.Culture = CultureInfo.InvariantCulture;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000A062 File Offset: 0x00008262
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x0000A06A File Offset: 0x0000826A
		public CultureInfo Culture { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000A073 File Offset: 0x00008273
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x0000A07B File Offset: 0x0000827B
		public string RootElement { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000A084 File Offset: 0x00008284
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x0000A08C File Offset: 0x0000828C
		public string Namespace { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x0000A095 File Offset: 0x00008295
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x0000A09D File Offset: 0x0000829D
		public string DateFormat { get; set; }

		// Token: 0x0600047E RID: 1150 RVA: 0x0000A0A8 File Offset: 0x000082A8
		public virtual T Deserialize<[Nullable(2)] T>(IRestResponse response)
		{
			if (string.IsNullOrEmpty(response.Content))
			{
				return default(T);
			}
			XDocument xdocument = XDocument.Parse(response.Content);
			XElement root = xdocument.Root;
			if (this.RootElement.HasValue() && xdocument.Root != null)
			{
				root = xdocument.Root.DescendantsAndSelf(this.RootElement.AsNamespaced(this.Namespace)).SingleOrDefault<XElement>();
			}
			if (!this.Namespace.HasValue())
			{
				XmlDeserializer.RemoveNamespace(xdocument);
			}
			T t = Activator.CreateInstance<T>();
			Type type = t.GetType();
			if (type.IsSubclassOfRawGeneric(typeof(List<>)))
			{
				t = (T)((object)this.HandleListDerivative(root, type.Name, type));
			}
			else
			{
				t = (T)((object)this.Map(t, root));
			}
			return t;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000A17C File Offset: 0x0000837C
		private static void RemoveNamespace(XDocument xdoc)
		{
			if (xdoc.Root == null)
			{
				return;
			}
			foreach (XElement xelement in xdoc.Root.DescendantsAndSelf())
			{
				if (xelement.Name.Namespace != XNamespace.None)
				{
					xelement.Name = XNamespace.None.GetName(xelement.Name.LocalName);
				}
				if (xelement.Attributes().Any((XAttribute a) => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None))
				{
					xelement.ReplaceAttributes(xelement.Attributes().Select(delegate(XAttribute a)
					{
						if (a.IsNamespaceDeclaration)
						{
							return null;
						}
						if (!(a.Name.Namespace != XNamespace.None))
						{
							return a;
						}
						return new XAttribute(XNamespace.None.GetName(a.Name.LocalName), a.Value);
					}));
				}
			}
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000A264 File Offset: 0x00008464
		protected virtual object Map(object x, XElement root)
		{
			PropertyInfo[] properties = x.GetType().GetProperties();
			bool flag = false;
			foreach (PropertyInfo propertyInfo in properties)
			{
				TypeInfo typeInfo = propertyInfo.PropertyType.GetTypeInfo();
				if ((typeInfo.IsPublic || typeInfo.IsNestedPublic) && propertyInfo.CanWrite)
				{
					bool flag2 = false;
					bool useExactName = false;
					XName xname = null;
					object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(DeserializeAsAttribute), false);
					if (customAttributes.Any<object>())
					{
						DeserializeAsAttribute deserializeAsAttribute = (DeserializeAsAttribute)customAttributes.First<object>();
						xname = deserializeAsAttribute.Name.AsNamespaced(this.Namespace);
						useExactName = !string.IsNullOrEmpty((xname != null) ? xname.LocalName : null);
						flag2 = deserializeAsAttribute.Content;
						if (flag && flag2)
						{
							throw new ArgumentException("Class cannot have two properties marked with SerializeAs(Content = true) attribute.");
						}
						flag = (flag || flag2);
					}
					if (xname == null)
					{
						xname = propertyInfo.Name.AsNamespaced(this.Namespace);
					}
					object obj = this.GetValueFromXml(root, xname, propertyInfo, useExactName);
					if (obj == null)
					{
						if (flag2)
						{
							XNode xnode = root.Nodes().FirstOrDefault((XNode n) => n is XText);
							if (xnode != null)
							{
								obj = ((XText)xnode).Value;
								propertyInfo.SetValue(x, obj, null);
							}
						}
						else if (typeInfo.IsGenericType)
						{
							Type type = typeInfo.GetGenericArguments()[0];
							XElement elementByName = this.GetElementByName(root, type.Name);
							IList list = (IList)Activator.CreateInstance(typeInfo.AsType());
							if (elementByName != null && root != null)
							{
								IEnumerable<XElement> elements = root.Elements(elementByName.Name);
								this.PopulateListFromElements(type, elements, list);
							}
							propertyInfo.SetValue(x, list, null);
						}
					}
					else
					{
						if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>))
						{
							if (string.IsNullOrEmpty(obj.ToString()))
							{
								propertyInfo.SetValue(x, null, null);
								goto IL_5A8;
							}
							typeInfo = typeInfo.GetGenericArguments()[0].GetTypeInfo();
						}
						Type type2 = typeInfo.AsType();
						if (type2 == typeof(bool))
						{
							string s = obj.ToString().ToLower(this.Culture);
							propertyInfo.SetValue(x, XmlConvert.ToBoolean(s), null);
						}
						else
						{
							if (typeInfo.IsPrimitive)
							{
								try
								{
									propertyInfo.SetValue(x, obj.ChangeType(type2), null);
									goto IL_5A8;
								}
								catch (FormatException ex)
								{
									throw new FormatException(string.Format("Couldn't parse the value of '{0}' into the '{1}'", obj, propertyInfo.Name) + string.Format(" property, because it isn't a type of '{0}'.", propertyInfo.PropertyType), ex.InnerException);
								}
							}
							if (typeInfo.IsEnum)
							{
								object value = typeInfo.AsType().FindEnumValue(obj.ToString(), this.Culture);
								propertyInfo.SetValue(x, value, null);
							}
							else if (type2 == typeof(Uri))
							{
								Uri value2 = new Uri(obj.ToString(), UriKind.RelativeOrAbsolute);
								propertyInfo.SetValue(x, value2, null);
							}
							else if (type2 == typeof(string))
							{
								propertyInfo.SetValue(x, obj, null);
							}
							else if (type2 == typeof(DateTime))
							{
								obj = (this.DateFormat.HasValue() ? DateTime.ParseExact(obj.ToString(), this.DateFormat, this.Culture) : DateTime.Parse(obj.ToString(), this.Culture));
								propertyInfo.SetValue(x, obj, null);
							}
							else
							{
								if (type2 == typeof(DateTimeOffset))
								{
									string text = obj.ToString();
									if (string.IsNullOrEmpty(text))
									{
										goto IL_5A8;
									}
									try
									{
										DateTimeOffset dateTimeOffset = XmlConvert.ToDateTimeOffset(text);
										propertyInfo.SetValue(x, dateTimeOffset, null);
										goto IL_5A8;
									}
									catch (Exception)
									{
										object value3;
										if (XmlDeserializer.TryGetFromString(text, out value3, type2))
										{
											propertyInfo.SetValue(x, value3, null);
										}
										else
										{
											DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(text);
											propertyInfo.SetValue(x, dateTimeOffset, null);
										}
										goto IL_5A8;
									}
								}
								object value5;
								if (type2 == typeof(decimal))
								{
									obj = decimal.Parse(obj.ToString(), this.Culture);
									propertyInfo.SetValue(x, obj, null);
								}
								else if (type2 == typeof(Guid))
								{
									obj = (string.IsNullOrEmpty(obj.ToString()) ? Guid.Empty : new Guid(obj.ToString()));
									propertyInfo.SetValue(x, obj, null);
								}
								else if (type2 == typeof(TimeSpan))
								{
									TimeSpan timeSpan = XmlConvert.ToTimeSpan(obj.ToString());
									propertyInfo.SetValue(x, timeSpan, null);
								}
								else if (typeInfo.IsGenericType)
								{
									IList list2 = (IList)Activator.CreateInstance(type2);
									XElement elementByName2 = this.GetElementByName(root, xname);
									if (elementByName2.HasElements)
									{
										XElement xelement = elementByName2.Elements().FirstOrDefault<XElement>();
										if (xelement != null)
										{
											Type t = typeInfo.GetGenericArguments()[0];
											IEnumerable<XElement> elements2 = elementByName2.Elements(xelement.Name);
											this.PopulateListFromElements(t, elements2, list2);
										}
									}
									propertyInfo.SetValue(x, list2, null);
								}
								else if (type2.IsSubclassOfRawGeneric(typeof(List<>)))
								{
									object value4 = this.HandleListDerivative(root, propertyInfo.Name, type2);
									propertyInfo.SetValue(x, value4, null);
								}
								else if (XmlDeserializer.TryGetFromString(obj.ToString(), out value5, type2))
								{
									propertyInfo.SetValue(x, value5, null);
								}
								else if (root != null)
								{
									XElement elementByName3 = this.GetElementByName(root, xname);
									if (elementByName3 != null)
									{
										object value6 = this.CreateAndMap(type2, elementByName3);
										propertyInfo.SetValue(x, value6, null);
									}
								}
							}
						}
					}
				}
				IL_5A8:;
			}
			return x;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000A844 File Offset: 0x00008A44
		private static bool TryGetFromString(string inputString, out object result, Type type)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(type);
			if (converter.CanConvertFrom(typeof(string)))
			{
				result = converter.ConvertFromInvariantString(inputString);
				return true;
			}
			result = null;
			return false;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0000A87C File Offset: 0x00008A7C
		private void PopulateListFromElements(Type t, IEnumerable<XElement> elements, IList list)
		{
			Func<XElement, object> <>9__0;
			Func<XElement, object> selector;
			if ((selector = <>9__0) == null)
			{
				selector = (<>9__0 = ((XElement element) => this.CreateAndMap(t, element)));
			}
			foreach (object value in elements.Select(selector))
			{
				list.Add(value);
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000A900 File Offset: 0x00008B00
		private object HandleListDerivative(XElement root, string propName, Type type)
		{
			Type type2 = type.IsGenericType ? type.GetGenericArguments()[0] : type.BaseType.GetGenericArguments()[0];
			IList list = (IList)Activator.CreateInstance(type);
			IList<XElement> list2 = root.Descendants(type2.Name.AsNamespaced(this.Namespace)).ToList<XElement>();
			string name = type2.Name;
			DeserializeAsAttribute attribute = type2.GetAttribute<DeserializeAsAttribute>();
			if (attribute != null)
			{
				name = attribute.Name;
			}
			if (!list2.Any<XElement>())
			{
				XName name3 = name.ToLower(this.Culture).AsNamespaced(this.Namespace);
				list2 = root.Descendants(name3).ToList<XElement>();
			}
			if (!list2.Any<XElement>())
			{
				XName name2 = name.ToCamelCase(this.Culture).AsNamespaced(this.Namespace);
				list2 = root.Descendants(name2).ToList<XElement>();
			}
			if (!list2.Any<XElement>())
			{
				list2 = (from e in root.Descendants()
				where e.Name.LocalName.RemoveUnderscoresAndDashes() == name
				select e).ToList<XElement>();
			}
			if (!list2.Any<XElement>())
			{
				XName lowerName = name.ToLower(this.Culture).AsNamespaced(this.Namespace);
				list2 = (from e in root.Descendants()
				where e.Name.LocalName.RemoveUnderscoresAndDashes() == lowerName
				select e).ToList<XElement>();
			}
			this.PopulateListFromElements(type2, list2, list);
			if (!type.IsGenericType)
			{
				this.Map(list, root.Element(propName.AsNamespaced(this.Namespace)) ?? root);
			}
			return list;
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000AA90 File Offset: 0x00008C90
		protected virtual object CreateAndMap(Type t, XElement element)
		{
			object obj;
			if (t == typeof(string))
			{
				obj = element.Value;
			}
			else if (t.GetTypeInfo().IsPrimitive)
			{
				obj = element.Value.ChangeType(t);
			}
			else
			{
				obj = Activator.CreateInstance(t);
				this.Map(obj, element);
			}
			return obj;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		protected virtual object GetValueFromXml(XElement root, XName name, PropertyInfo prop, bool useExactName)
		{
			object result = null;
			if (root == null)
			{
				return result;
			}
			XElement elementByName = this.GetElementByName(root, name);
			if (elementByName == null)
			{
				XAttribute attributeByName = this.GetAttributeByName(root, name, useExactName);
				if (attributeByName != null)
				{
					result = attributeByName.Value;
				}
			}
			else if (!elementByName.IsEmpty || elementByName.HasElements || elementByName.HasAttributes)
			{
				result = elementByName.Value;
			}
			return result;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000AB40 File Offset: 0x00008D40
		protected virtual XElement GetElementByName(XElement root, XName name)
		{
			XName name2 = name.LocalName.ToLower(this.Culture).AsNamespaced(name.NamespaceName);
			XName name3 = name.LocalName.ToCamelCase(this.Culture).AsNamespaced(name.NamespaceName);
			if (root.Element(name) != null)
			{
				return root.Element(name);
			}
			if (root.Element(name2) != null)
			{
				return root.Element(name2);
			}
			if (root.Element(name3) != null)
			{
				return root.Element(name3);
			}
			IOrderedEnumerable<XElement> source = from d in root.Descendants()
			orderby d.Ancestors().Count<XElement>()
			select d;
			XElement xelement = source.FirstOrDefault((XElement d) => d.Name.LocalName.RemoveUnderscoresAndDashes() == name.LocalName) ?? source.FirstOrDefault((XElement d) => string.Equals(d.Name.LocalName.RemoveUnderscoresAndDashes(), name.LocalName, StringComparison.OrdinalIgnoreCase));
			if (xelement != null || !(name == "Value".AsNamespaced(name.NamespaceName)) || (root.HasAttributes && !root.Attributes().All((XAttribute x) => x.Name != name)))
			{
				return xelement;
			}
			return root;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000AC88 File Offset: 0x00008E88
		protected virtual XAttribute GetAttributeByName(XElement root, XName name, bool useExactName)
		{
			XmlDeserializer.<>c__DisplayClass26_0 CS$<>8__locals1 = new XmlDeserializer.<>c__DisplayClass26_0();
			CS$<>8__locals1.useExactName = useExactName;
			CS$<>8__locals1.name = name;
			XmlDeserializer.<>c__DisplayClass26_0 CS$<>8__locals2 = CS$<>8__locals1;
			List<XName> names;
			if (!CS$<>8__locals1.useExactName)
			{
				List<XName> list = new List<XName>();
				list.Add(CS$<>8__locals1.name.LocalName);
				list.Add(CS$<>8__locals1.name.LocalName.ToLower(this.Culture).AsNamespaced(CS$<>8__locals1.name.NamespaceName));
				names = list;
				list.Add(CS$<>8__locals1.name.LocalName.ToCamelCase(this.Culture).AsNamespaced(CS$<>8__locals1.name.NamespaceName));
			}
			else
			{
				names = null;
			}
			CS$<>8__locals2.names = names;
			return (from d in root.DescendantsAndSelf()
			orderby d.Ancestors().Count<XElement>()
			select d).Attributes().FirstOrDefault(delegate(XAttribute d)
			{
				if (!CS$<>8__locals1.useExactName)
				{
					return CS$<>8__locals1.names.Contains(d.Name.LocalName.RemoveUnderscoresAndDashes());
				}
				return d.Name == CS$<>8__locals1.name;
			});
		}
	}
}
