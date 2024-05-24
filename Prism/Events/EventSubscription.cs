using System;
using System.Globalization;
using Prism.Properties;

namespace Prism.Events
{
	// Token: 0x02000015 RID: 21
	public class EventSubscription : IEventSubscription
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public EventSubscription(IDelegateReference actionReference)
		{
			if (actionReference == null)
			{
				throw new ArgumentNullException("actionReference");
			}
			if (!(actionReference.Target is Action))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidDelegateRerefenceTypeException, new object[]
				{
					typeof(Action).FullName
				}), "actionReference");
			}
			this._actionReference = actionReference;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002B57 File Offset: 0x00000D57
		public Action Action
		{
			get
			{
				return (Action)this._actionReference.Target;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002B69 File Offset: 0x00000D69
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002B71 File Offset: 0x00000D71
		public SubscriptionToken SubscriptionToken { get; set; }

		// Token: 0x06000053 RID: 83 RVA: 0x00002B7C File Offset: 0x00000D7C
		public virtual Action<object[]> GetExecutionStrategy()
		{
			Action action = this.Action;
			if (action != null)
			{
				return delegate(object[] arguments)
				{
					this.InvokeAction(action);
				};
			}
			return null;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public virtual void InvokeAction(Action action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			action();
		}

		// Token: 0x04000021 RID: 33
		private readonly IDelegateReference _actionReference;
	}
}
