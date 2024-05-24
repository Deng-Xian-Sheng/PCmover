using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000326 RID: 806
	[DataContract]
	public class CompositingReasonsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x060017A9 RID: 6057 RVA: 0x0001B98F File Offset: 0x00019B8F
		// (set) Token: 0x060017AA RID: 6058 RVA: 0x0001B997 File Offset: 0x00019B97
		[DataMember]
		internal string[] compositingReasons { get; set; }

		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x060017AB RID: 6059 RVA: 0x0001B9A0 File Offset: 0x00019BA0
		public string[] CompositingReasons
		{
			get
			{
				return this.compositingReasons;
			}
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x0001B9A8 File Offset: 0x00019BA8
		// (set) Token: 0x060017AD RID: 6061 RVA: 0x0001B9B0 File Offset: 0x00019BB0
		[DataMember]
		internal string[] compositingReasonIds { get; set; }

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x0001B9B9 File Offset: 0x00019BB9
		public string[] CompositingReasonIds
		{
			get
			{
				return this.compositingReasonIds;
			}
		}
	}
}
