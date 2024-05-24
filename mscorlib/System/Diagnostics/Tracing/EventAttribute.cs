using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000426 RID: 1062
	[AttributeUsage(AttributeTargets.Method)]
	[__DynamicallyInvokable]
	public sealed class EventAttribute : Attribute
	{
		// Token: 0x0600352A RID: 13610 RVA: 0x000CE614 File Offset: 0x000CC814
		[__DynamicallyInvokable]
		public EventAttribute(int eventId)
		{
			this.EventId = eventId;
			this.Level = EventLevel.Informational;
			this.m_opcodeSet = false;
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x0600352B RID: 13611 RVA: 0x000CE631 File Offset: 0x000CC831
		// (set) Token: 0x0600352C RID: 13612 RVA: 0x000CE639 File Offset: 0x000CC839
		[__DynamicallyInvokable]
		public int EventId { [__DynamicallyInvokable] get; private set; }

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x0600352D RID: 13613 RVA: 0x000CE642 File Offset: 0x000CC842
		// (set) Token: 0x0600352E RID: 13614 RVA: 0x000CE64A File Offset: 0x000CC84A
		[__DynamicallyInvokable]
		public EventLevel Level { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x0600352F RID: 13615 RVA: 0x000CE653 File Offset: 0x000CC853
		// (set) Token: 0x06003530 RID: 13616 RVA: 0x000CE65B File Offset: 0x000CC85B
		[__DynamicallyInvokable]
		public EventKeywords Keywords { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06003531 RID: 13617 RVA: 0x000CE664 File Offset: 0x000CC864
		// (set) Token: 0x06003532 RID: 13618 RVA: 0x000CE66C File Offset: 0x000CC86C
		[__DynamicallyInvokable]
		public EventOpcode Opcode
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_opcode;
			}
			[__DynamicallyInvokable]
			set
			{
				this.m_opcode = value;
				this.m_opcodeSet = true;
			}
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06003533 RID: 13619 RVA: 0x000CE67C File Offset: 0x000CC87C
		internal bool IsOpcodeSet
		{
			get
			{
				return this.m_opcodeSet;
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06003534 RID: 13620 RVA: 0x000CE684 File Offset: 0x000CC884
		// (set) Token: 0x06003535 RID: 13621 RVA: 0x000CE68C File Offset: 0x000CC88C
		[__DynamicallyInvokable]
		public EventTask Task { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06003536 RID: 13622 RVA: 0x000CE695 File Offset: 0x000CC895
		// (set) Token: 0x06003537 RID: 13623 RVA: 0x000CE69D File Offset: 0x000CC89D
		[__DynamicallyInvokable]
		public EventChannel Channel { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06003538 RID: 13624 RVA: 0x000CE6A6 File Offset: 0x000CC8A6
		// (set) Token: 0x06003539 RID: 13625 RVA: 0x000CE6AE File Offset: 0x000CC8AE
		[__DynamicallyInvokable]
		public byte Version { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x0600353A RID: 13626 RVA: 0x000CE6B7 File Offset: 0x000CC8B7
		// (set) Token: 0x0600353B RID: 13627 RVA: 0x000CE6BF File Offset: 0x000CC8BF
		[__DynamicallyInvokable]
		public string Message { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x0600353C RID: 13628 RVA: 0x000CE6C8 File Offset: 0x000CC8C8
		// (set) Token: 0x0600353D RID: 13629 RVA: 0x000CE6D0 File Offset: 0x000CC8D0
		[__DynamicallyInvokable]
		public EventTags Tags { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x0600353E RID: 13630 RVA: 0x000CE6D9 File Offset: 0x000CC8D9
		// (set) Token: 0x0600353F RID: 13631 RVA: 0x000CE6E1 File Offset: 0x000CC8E1
		[__DynamicallyInvokable]
		public EventActivityOptions ActivityOptions { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x0400179B RID: 6043
		private EventOpcode m_opcode;

		// Token: 0x0400179C RID: 6044
		private bool m_opcodeSet;
	}
}
