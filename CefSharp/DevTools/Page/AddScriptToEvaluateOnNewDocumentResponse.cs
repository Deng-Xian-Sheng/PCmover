using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000272 RID: 626
	[DataContract]
	public class AddScriptToEvaluateOnNewDocumentResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x060011B0 RID: 4528 RVA: 0x00015F28 File Offset: 0x00014128
		// (set) Token: 0x060011B1 RID: 4529 RVA: 0x00015F30 File Offset: 0x00014130
		[DataMember]
		internal string identifier { get; set; }

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x00015F39 File Offset: 0x00014139
		public string Identifier
		{
			get
			{
				return this.identifier;
			}
		}
	}
}
