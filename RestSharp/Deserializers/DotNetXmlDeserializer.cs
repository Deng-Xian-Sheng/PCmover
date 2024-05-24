using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using RestSharp.Serialization;
using RestSharp.Serialization.Xml;

namespace RestSharp.Deserializers
{
	// Token: 0x02000039 RID: 57
	[NullableContext(1)]
	[Nullable(0)]
	public class DotNetXmlDeserializer : IXmlDeserializer, IDeserializer, IWithRootElement
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00009F81 File Offset: 0x00008181
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x00009F89 File Offset: 0x00008189
		public Encoding Encoding { get; set; } = Encoding.UTF8;

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x00009F92 File Offset: 0x00008192
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x00009F9A File Offset: 0x0000819A
		public string RootElement { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x00009FA3 File Offset: 0x000081A3
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x00009FAB File Offset: 0x000081AB
		public string Namespace { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x00009FB4 File Offset: 0x000081B4
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x00009FBC File Offset: 0x000081BC
		public string DateFormat { get; set; }

		// Token: 0x06000473 RID: 1139 RVA: 0x00009FC8 File Offset: 0x000081C8
		public T Deserialize<[Nullable(2)] T>(IRestResponse response)
		{
			T result;
			if (string.IsNullOrEmpty(response.Content))
			{
				result = default(T);
				return result;
			}
			using (MemoryStream memoryStream = new MemoryStream(this.Encoding.GetBytes(response.Content)))
			{
				result = (T)((object)new XmlSerializer(typeof(T)).Deserialize(memoryStream));
			}
			return result;
		}
	}
}
