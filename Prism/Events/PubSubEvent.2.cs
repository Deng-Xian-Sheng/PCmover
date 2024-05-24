using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Properties;

namespace Prism.Events
{
	// Token: 0x0200001B RID: 27
	public class PubSubEvent<TPayload> : EventBase
	{
		// Token: 0x06000069 RID: 105 RVA: 0x00002EA8 File Offset: 0x000010A8
		public SubscriptionToken Subscribe(Action<TPayload> action)
		{
			return this.Subscribe(action, ThreadOption.PublisherThread);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002EB2 File Offset: 0x000010B2
		public SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption)
		{
			return this.Subscribe(action, threadOption, false);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002EBD File Offset: 0x000010BD
		public SubscriptionToken Subscribe(Action<TPayload> action, bool keepSubscriberReferenceAlive)
		{
			return this.Subscribe(action, ThreadOption.PublisherThread, keepSubscriberReferenceAlive);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002EC8 File Offset: 0x000010C8
		public SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption, bool keepSubscriberReferenceAlive)
		{
			return this.Subscribe(action, threadOption, keepSubscriberReferenceAlive, null);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002ED4 File Offset: 0x000010D4
		public virtual SubscriptionToken Subscribe(Action<TPayload> action, ThreadOption threadOption, bool keepSubscriberReferenceAlive, Predicate<TPayload> filter)
		{
			IDelegateReference actionReference = new DelegateReference(action, keepSubscriberReferenceAlive);
			IDelegateReference filterReference;
			if (filter != null)
			{
				filterReference = new DelegateReference(filter, keepSubscriberReferenceAlive);
			}
			else
			{
				filterReference = new DelegateReference(new Predicate<TPayload>((TPayload <obj>) => true), true);
			}
			EventSubscription<TPayload> eventSubscription;
			switch (threadOption)
			{
			case ThreadOption.PublisherThread:
				eventSubscription = new EventSubscription<TPayload>(actionReference, filterReference);
				break;
			case ThreadOption.UIThread:
				if (base.SynchronizationContext == null)
				{
					throw new InvalidOperationException(Resources.EventAggregatorNotConstructedOnUIThread);
				}
				eventSubscription = new DispatcherEventSubscription<TPayload>(actionReference, filterReference, base.SynchronizationContext);
				break;
			case ThreadOption.BackgroundThread:
				eventSubscription = new BackgroundEventSubscription<TPayload>(actionReference, filterReference);
				break;
			default:
				eventSubscription = new EventSubscription<TPayload>(actionReference, filterReference);
				break;
			}
			return this.InternalSubscribe(eventSubscription);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002F78 File Offset: 0x00001178
		public virtual void Publish(TPayload payload)
		{
			this.InternalPublish(new object[]
			{
				payload
			});
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002F90 File Offset: 0x00001190
		public virtual void Unsubscribe(Action<TPayload> subscriber)
		{
			ICollection<IEventSubscription> subscriptions = base.Subscriptions;
			lock (subscriptions)
			{
				IEventSubscription eventSubscription = base.Subscriptions.Cast<EventSubscription<TPayload>>().FirstOrDefault((EventSubscription<TPayload> evt) => evt.Action == subscriber);
				if (eventSubscription != null)
				{
					base.Subscriptions.Remove(eventSubscription);
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003004 File Offset: 0x00001204
		public virtual bool Contains(Action<TPayload> subscriber)
		{
			ICollection<IEventSubscription> subscriptions = base.Subscriptions;
			IEventSubscription eventSubscription;
			lock (subscriptions)
			{
				eventSubscription = base.Subscriptions.Cast<EventSubscription<TPayload>>().FirstOrDefault((EventSubscription<TPayload> evt) => evt.Action == subscriber);
			}
			return eventSubscription != null;
		}
	}
}
