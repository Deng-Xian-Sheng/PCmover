using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200001E RID: 30
	[NullableContext(2)]
	[Nullable(0)]
	public class XmlParameter : Parameter
	{
		// Token: 0x06000307 RID: 775 RVA: 0x000060B7 File Offset: 0x000042B7
		[NullableContext(1)]
		public XmlParameter(string name, object value, [Nullable(2)] string xmlNamespace = null) : base(name, value, ParameterType.RequestBody)
		{
			this.XmlNamespace = xmlNamespace;
			base.DataFormat = DataFormat.Xml;
			base.ContentType = "application/xml";
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000060DB File Offset: 0x000042DB
		public string XmlNamespace { get; }
	}
}
