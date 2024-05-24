using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Properties;

namespace Prism.Events
{
	// Token: 0x0200001A RID: 26
	public class PubSubEvent : EventBase
	{
		// Token: 0x06000061 RID: 97 RVA: 0x00002D27 File Offset: 0x00000F27
		public SubscriptionToken Subscribe(Action action)
		{
			return this.Subscribe(action, ThreadOption.PublisherThread);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00002D31 File Offset: 0x00000F31
		public SubscriptionToken Subscribe(Action action, ThreadOption threadOption)
		{
			return this.Subscribe(action, threadOption, false);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002D3C File Offset: 0x00000F3C
		public SubscriptionToken Subscribe(Action action, bool keepSubscriberReferenceAlive)
		{
			return this.Subscribe(action, ThreadOption.PublisherThread, keepSubscriberReferenceAlive);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002D48 File Offset: 0x00000F48
		public virtual SubscriptionToken Subscribe(Action action, ThreadOption threadOption, bool keepSubscriberReferenceAlive)
		{
			IDelegateReference actionReference = new DelegateReference(action, keepSubscriberReferenceAlive);
			EventSubscription eventSubscription;
			switch (threadOption)
			{
			case ThreadOption.PublisherThread:
				eventSubscription = new EventSubscription(actionReference);
				break;
			case ThreadOption.UIThread:
				if (base.SynchronizationContext == null)
				{
					throw new InvalidOperationException(Resources.EventAggregatorNotConstructedOnUIThread);
				}
				eventSubscription = new DispatcherEventSubscription(actionReference, base.SynchronizationContext);
				break;
			case ThreadOption.BackgroundThread:
				eventSubscription = new BackgroundEventSubscription(actionReference);
				break;
			default:
				eventSubscription = new EventSubscription(actionReference);
				break;
			}
			return this.InternalSubscribe(eventSubscription);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002DB3 File Offset: 0x00000FB3
		public virtual void Publish()
		{
			this.InternalPublish(new object[0]);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public virtual void Unsubscribe(Action subscriber)
		{
			ICollection<IEventSubscription> subscriptions = base.Subscriptions;
			lock (subscriptions)
			{
				IEventSubscription eventSubscription = base.Subscriptions.Cast<EventSubscription>().FirstOrDefault((EventSubscription evt) => evt.Action == subscriber);
				if (eventSubscription != null)
				{
					base.Subscriptions.Remove(eventSubscription);
				}
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002E38 File Offset: 0x00001038
		public virtual bool Contains(Action subscriber)
		{
			ICollection<IEventSubscription> subscriptions = base.Subscriptions;
			IEventSubscription eventSubscription;
			lock (subscriptions)
			{
				eventSubscription = base.Subscriptions.Cast<EventSubscription>().FirstOrDefault((EventSubscription evt) => evt.Action == subscriber);
			}
			return eventSubscription != null;
		}
	}
}
