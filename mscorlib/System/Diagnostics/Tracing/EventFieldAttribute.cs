using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000442 RID: 1090
	[AttributeUsage(AttributeTargets.Property)]
	[__DynamicallyInvokable]
	public class EventFieldAttribute : Attribute
	{
		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06003600 RID: 13824 RVA: 0x000D2362 File Offset: 0x000D0562
		// (set) Token: 0x06003601 RID: 13825 RVA: 0x000D236A File Offset: 0x000D056A
		[__DynamicallyInvokable]
		public EventFieldTags Tags { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06003602 RID: 13826 RVA: 0x000D2373 File Offset: 0x000D0573
		// (set) Token: 0x06003603 RID: 13827 RVA: 0x000D237B File Offset: 0x000D057B
		internal string Name { get; set; }

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06003604 RID: 13828 RVA: 0x000D2384 File Offset: 0x000D0584
		// (set) Token: 0x06003605 RID: 13829 RVA: 0x000D238C File Offset: 0x000D058C
		[__DynamicallyInvokable]
		public EventFieldFormat Format { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x06003606 RID: 13830 RVA: 0x000D2395 File Offset: 0x000D0595
		[__DynamicallyInvokable]
		public EventFieldAttribute()
		{
		}
	}
}
