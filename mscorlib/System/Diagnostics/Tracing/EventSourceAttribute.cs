using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000425 RID: 1061
	[AttributeUsage(AttributeTargets.Class)]
	[__DynamicallyInvokable]
	public sealed class EventSourceAttribute : Attribute
	{
		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x06003523 RID: 13603 RVA: 0x000CE5D9 File Offset: 0x000CC7D9
		// (set) Token: 0x06003524 RID: 13604 RVA: 0x000CE5E1 File Offset: 0x000CC7E1
		[__DynamicallyInvokable]
		public string Name { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06003525 RID: 13605 RVA: 0x000CE5EA File Offset: 0x000CC7EA
		// (set) Token: 0x06003526 RID: 13606 RVA: 0x000CE5F2 File Offset: 0x000CC7F2
		[__DynamicallyInvokable]
		public string Guid { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06003527 RID: 13607 RVA: 0x000CE5FB File Offset: 0x000CC7FB
		// (set) Token: 0x06003528 RID: 13608 RVA: 0x000CE603 File Offset: 0x000CC803
		[__DynamicallyInvokable]
		public string LocalizationResources { [__DynamicallyInvokable] get; [__DynamicallyInvokable] set; }

		// Token: 0x06003529 RID: 13609 RVA: 0x000CE60C File Offset: 0x000CC80C
		[__DynamicallyInvokable]
		public EventSourceAttribute()
		{
		}
	}
}
