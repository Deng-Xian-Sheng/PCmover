using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000440 RID: 1088
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	[__DynamicallyInvokable]
	public class EventDataAttribute : Attribute
	{
		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x060035F5 RID: 13813 RVA: 0x000D22F7 File Offset: 0x000D04F7
		// (set) Token: 0x060035F6 RID: 13814 RVA: 0x000D22FF File Offset: 0x000D04FF
		[__DynamicallyInvokable]
		public string Name { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x060035F7 RID: 13815 RVA: 0x000D2308 File Offset: 0x000D0508
		// (set) Token: 0x060035F8 RID: 13816 RVA: 0x000D2310 File Offset: 0x000D0510
		internal EventLevel Level
		{
			get
			{
				return this.level;
			}
			set
			{
				this.level = value;
			}
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x060035F9 RID: 13817 RVA: 0x000D2319 File Offset: 0x000D0519
		// (set) Token: 0x060035FA RID: 13818 RVA: 0x000D2321 File Offset: 0x000D0521
		internal EventOpcode Opcode
		{
			get
			{
				return this.opcode;
			}
			set
			{
				this.opcode = value;
			}
		}

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x060035FB RID: 13819 RVA: 0x000D232A File Offset: 0x000D052A
		// (set) Token: 0x060035FC RID: 13820 RVA: 0x000D2332 File Offset: 0x000D0532
		internal EventKeywords Keywords { get; set; }

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x060035FD RID: 13821 RVA: 0x000D233B File Offset: 0x000D053B
		// (set) Token: 0x060035FE RID: 13822 RVA: 0x000D2343 File Offset: 0x000D0543
		internal EventTags Tags { get; set; }

		// Token: 0x060035FF RID: 13823 RVA: 0x000D234C File Offset: 0x000D054C
		[__DynamicallyInvokable]
		public EventDataAttribute()
		{
		}

		// Token: 0x04001816 RID: 6166
		private EventLevel level = (EventLevel)(-1);

		// Token: 0x04001817 RID: 6167
		private EventOpcode opcode = (EventOpcode)(-1);
	}
}
