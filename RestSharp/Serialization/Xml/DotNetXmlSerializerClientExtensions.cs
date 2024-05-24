using System;
using System.Runtime.CompilerServices;
using System.Text;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x0200003E RID: 62
	public static class DotNetXmlSerializerClientExtensions
	{
		// Token: 0x0600048E RID: 1166 RVA: 0x0000AE00 File Offset: 0x00009000
		[NullableContext(1)]
		public static IRestClient UseDotNetXmlSerializer(this IRestClient restClient, string xmlNamespace = null, Encoding encoding = null)
		{
			DotNetXmlSerializer dotNetXmlSerializer = new DotNetXmlSerializer();
			if (xmlNamespace != null)
			{
				dotNetXmlSerializer.Namespace = xmlNamespace;
			}
			if (encoding != null)
			{
				dotNetXmlSerializer.Encoding = encoding;
			}
			DotNetXmlDeserializer dotNetXmlDeserializer = new DotNetXmlDeserializer();
			if (encoding != null)
			{
				dotNetXmlDeserializer.Encoding = encoding;
			}
			XmlRestSerializer serializer = new XmlRestSerializer().WithXmlSerializer(dotNetXmlSerializer).WithXmlDeserializer(dotNetXmlDeserializer);
			return restClient.UseSerializer(() => serializer);
		}
	}
}
