using System;

namespace Prism.Events
{
	// Token: 0x02000019 RID: 25
	public interface IEventSubscription
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005E RID: 94
		// (set) Token: 0x0600005F RID: 95
		SubscriptionToken SubscriptionToken { get; set; }

		// Token: 0x06000060 RID: 96
		Action<object[]> GetExecutionStrategy();
	}
}
