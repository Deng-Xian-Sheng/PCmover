using System;

namespace Prism.Events
{
	// Token: 0x02000018 RID: 24
	public interface IEventAggregator
	{
		// Token: 0x0600005D RID: 93
		TEventType GetEvent<TEventType>() where TEventType : EventBase, new();
	}
}
