using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Prism.Events
{
	// Token: 0x02000014 RID: 20
	public abstract class EventBase
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000289E File Offset: 0x00000A9E
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000028A6 File Offset: 0x00000AA6
		public SynchronizationContext SynchronizationContext { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000028AF File Offset: 0x00000AAF
		protected ICollection<IEventSubscription> Subscriptions
		{
			get
			{
				return this._subscriptions;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000028B8 File Offset: 0x00000AB8
		protected virtual SubscriptionToken InternalSubscribe(IEventSubscription eventSubscription)
		{
			if (eventSubscription == null)
			{
				throw new ArgumentNullException("eventSubscription");
			}
			eventSubscription.SubscriptionToken = new SubscriptionToken(new Action<SubscriptionToken>(this.Unsubscribe));
			ICollection<IEventSubscription> subscriptions = this.Subscriptions;
			lock (subscriptions)
			{
				this.Subscriptions.Add(eventSubscription);
			}
			return eventSubscription.SubscriptionToken;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000292C File Offset: 0x00000B2C
		protected virtual void InternalPublish(params object[] arguments)
		{
			foreach (Action<object[]> action in this.PruneAndReturnStrategies())
			{
				action(arguments);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002980 File Offset: 0x00000B80
		public virtual void Unsubscribe(SubscriptionToken token)
		{
			ICollection<IEventSubscription> subscriptions = this.Subscriptions;
			lock (subscriptions)
			{
				IEventSubscription eventSubscription = this.Subscriptions.FirstOrDefault((IEventSubscription evt) => evt.SubscriptionToken == token);
				if (eventSubscription != null)
				{
					this.Subscriptions.Remove(eventSubscription);
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000029F0 File Offset: 0x00000BF0
		public virtual bool Contains(SubscriptionToken token)
		{
			ICollection<IEventSubscription> subscriptions = this.Subscriptions;
			bool result;
			lock (subscriptions)
			{
				result = (this.Subscriptions.FirstOrDefault((IEventSubscription evt) => evt.SubscriptionToken == token) != null);
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00002A54 File Offset: 0x00000C54
		private List<Action<object[]>> PruneAndReturnStrategies()
		{
			List<Action<object[]>> list = new List<Action<object[]>>();
			ICollection<IEventSubscription> subscriptions = this.Subscriptions;
			lock (subscriptions)
			{
				for (int i = this.Subscriptions.Count - 1; i >= 0; i--)
				{
					Action<object[]> executionStrategy = this._subscriptions[i].GetExecutionStrategy();
					if (executionStrategy == null)
					{
						this._subscriptions.RemoveAt(i);
					}
					else
					{
						list.Add(executionStrategy);
					}
				}
			}
			return list;
		}

		// Token: 0x0400001F RID: 31
		private readonly List<IEventSubscription> _subscriptions = new List<IEventSubscription>();
	}
}
