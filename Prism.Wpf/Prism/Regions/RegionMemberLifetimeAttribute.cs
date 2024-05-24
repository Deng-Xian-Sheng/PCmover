using System;

namespace Prism.Regions
{
	// Token: 0x02000029 RID: 41
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	public sealed class RegionMemberLifetimeAttribute : Attribute
	{
		// Token: 0x0600010F RID: 271 RVA: 0x00003C73 File Offset: 0x00001E73
		public RegionMemberLifetimeAttribute()
		{
			this.KeepAlive = true;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00003C82 File Offset: 0x00001E82
		// (set) Token: 0x06000111 RID: 273 RVA: 0x00003C8A File Offset: 0x00001E8A
		public bool KeepAlive { get; set; }
	}
}
