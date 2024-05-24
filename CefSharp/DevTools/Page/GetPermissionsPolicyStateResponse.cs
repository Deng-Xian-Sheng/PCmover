using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000282 RID: 642
	[DataContract]
	public class GetPermissionsPolicyStateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x000162A8 File Offset: 0x000144A8
		// (set) Token: 0x0600121B RID: 4635 RVA: 0x000162B0 File Offset: 0x000144B0
		[DataMember]
		internal IList<PermissionsPolicyFeatureState> states { get; set; }

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x000162B9 File Offset: 0x000144B9
		public IList<PermissionsPolicyFeatureState> States
		{
			get
			{
				return this.states;
			}
		}
	}
}
