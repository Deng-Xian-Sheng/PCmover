using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using RestSharp.Deserializers;
using RestSharp.Extensions;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x02000041 RID: 65
	public class XmlAttributeDeserializer : XmlDeserializer
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x0000AE68 File Offset: 0x00009068
		[NullableContext(1)]
		protected override object GetValueFromXml(XElement root, XName name, PropertyInfo prop, bool useExactName)
		{
			bool flag = false;
			DeserializeAsAttribute attribute = prop.GetAttribute<DeserializeAsAttribute>();
			if (attribute != null)
			{
				string name2 = attribute.Name;
				name = ((name2 != null) ? name2 : name);
				flag = attribute.Attribute;
			}
			if (!flag)
			{
				return base.GetValueFromXml(root, name, prop, useExactName);
			}
			XAttribute attributeByName = this.GetAttributeByName(root, name, useExactName);
			return ((attributeByName != null) ? attributeByName.Value : null) ?? base.GetValueFromXml(root, name, prop, useExactName);
		}
	}
}
