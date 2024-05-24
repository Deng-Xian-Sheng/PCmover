using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using RestSharp.Serialization;
using RestSharp.Serialization.Xml;

namespace RestSharp.Serializers
{
	// Token: 0x02000035 RID: 53
	[NullableContext(1)]
	[Nullable(0)]
	public class DotNetXmlSerializer : IXmlSerializer, ISerializer, IWithRootElement
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x000097EE File Offset: 0x000079EE
		public DotNetXmlSerializer()
		{
			this.ContentType = "application/xml";
			this.Encoding = Encoding.UTF8;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000980C File Offset: 0x00007A0C
		public DotNetXmlSerializer(string @namespace) : this()
		{
			this.Namespace = @namespace;
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000981B File Offset: 0x00007A1B
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x00009823 File Offset: 0x00007A23
		public Encoding Encoding { get; set; }

		// Token: 0x0600044B RID: 1099 RVA: 0x0000982C File Offset: 0x00007A2C
		public string Serialize(object obj)
		{
			XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
			xmlSerializerNamespaces.Add(string.Empty, this.Namespace);
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			DotNetXmlSerializer.EncodingStringWriter encodingStringWriter = new DotNetXmlSerializer.EncodingStringWriter(this.Encoding);
			xmlSerializer.Serialize(encodingStringWriter, obj, xmlSerializerNamespaces);
			return encodingStringWriter.ToString();
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x00009875 File Offset: 0x00007A75
		// (set) Token: 0x0600044D RID: 1101 RVA: 0x0000987D File Offset: 0x00007A7D
		public string RootElement { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600044E RID: 1102 RVA: 0x00009886 File Offset: 0x00007A86
		// (set) Token: 0x0600044F RID: 1103 RVA: 0x0000988E File Offset: 0x00007A8E
		public string Namespace { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x00009897 File Offset: 0x00007A97
		// (set) Token: 0x06000451 RID: 1105 RVA: 0x0000989F File Offset: 0x00007A9F
		public string DateFormat { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x000098A8 File Offset: 0x00007AA8
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x000098B0 File Offset: 0x00007AB0
		public string ContentType { get; set; }

		// Token: 0x020000B9 RID: 185
		[Nullable(0)]
		private class EncodingStringWriter : StringWriter
		{
			// Token: 0x0600069A RID: 1690 RVA: 0x0000F538 File Offset: 0x0000D738
			public EncodingStringWriter(Encoding encoding)
			{
				this.Encoding = encoding;
			}

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000F547 File Offset: 0x0000D747
			public override Encoding Encoding { get; }
		}
	}
}
