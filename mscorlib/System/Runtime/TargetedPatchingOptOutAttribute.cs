using System;

namespace System.Runtime
{
	// Token: 0x02000718 RID: 1816
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public sealed class TargetedPatchingOptOutAttribute : Attribute
	{
		// Token: 0x0600512C RID: 20780 RVA: 0x0011E596 File Offset: 0x0011C796
		public TargetedPatchingOptOutAttribute(string reason)
		{
			this.m_reason = reason;
		}

		// Token: 0x17000D5A RID: 3418
		// (get) Token: 0x0600512D RID: 20781 RVA: 0x0011E5A5 File Offset: 0x0011C7A5
		public string Reason
		{
			get
			{
				return this.m_reason;
			}
		}

		// Token: 0x0600512E RID: 20782 RVA: 0x0011E5AD File Offset: 0x0011C7AD
		private TargetedPatchingOptOutAttribute()
		{
		}

		// Token: 0x040023F5 RID: 9205
		private string m_reason;
	}
}
