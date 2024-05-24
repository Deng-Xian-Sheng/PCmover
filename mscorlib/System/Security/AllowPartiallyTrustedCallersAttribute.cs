using System;
using System.Runtime.InteropServices;

namespace System.Security
{
	// Token: 0x020001C4 RID: 452
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AllowPartiallyTrustedCallersAttribute : Attribute
	{
		// Token: 0x06001C1B RID: 7195 RVA: 0x00060E11 File Offset: 0x0005F011
		[__DynamicallyInvokable]
		public AllowPartiallyTrustedCallersAttribute()
		{
		}

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06001C1C RID: 7196 RVA: 0x00060E19 File Offset: 0x0005F019
		// (set) Token: 0x06001C1D RID: 7197 RVA: 0x00060E21 File Offset: 0x0005F021
		public PartialTrustVisibilityLevel PartialTrustVisibilityLevel
		{
			get
			{
				return this._visibilityLevel;
			}
			set
			{
				this._visibilityLevel = value;
			}
		}

		// Token: 0x040009BE RID: 2494
		private PartialTrustVisibilityLevel _visibilityLevel;
	}
}
