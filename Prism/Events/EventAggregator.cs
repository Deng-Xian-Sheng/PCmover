using System;
using System.Collections.Generic;
using System.Threading;

namespace Prism.Events
{
	// Token: 0x02000013 RID: 19
	public class EventAggregator : IEventAggregator
	{
		// Token: 0x06000044 RID: 68 RVA: 0x000027E8 File Offset: 0x000009E8
		public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
		{
			Dictionary<Type, EventBase> obj = this.events;
			TEventType result;
			lock (obj)
			{
				EventBase eventBase = null;
				if (!this.events.TryGetValue(typeof(TEventType), out eventBase))
				{
					TEventType teventType = Activator.CreateInstance<TEventType>();
					teventType.SynchronizationContext = this.syncContext;
					this.events[typeof(TEventType)] = teventType;
					result = teventType;
				}
				else
				{
					result = (TEventType)((object)eventBase);
				}
			}
			return result;
		}

		// Token: 0x0400001D RID: 29
		private readonly Dictionary<Type, EventBase> events = new Dictionary<Type, EventBase>();

		// Token: 0x0400001E RID: 30
		private readonly SynchronizationContext syncContext = SynchronizationContext.Current;
	}
}
