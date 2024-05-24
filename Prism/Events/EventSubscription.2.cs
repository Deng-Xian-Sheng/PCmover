using System;
using System.Globalization;
using Prism.Properties;

namespace Prism.Events
{
	// Token: 0x02000016 RID: 22
	public class EventSubscription<TPayload> : IEventSubscription
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00002BD0 File Offset: 0x00000DD0
		public EventSubscription(IDelegateReference actionReference, IDelegateReference filterReference)
		{
			if (actionReference == null)
			{
				throw new ArgumentNullException("actionReference");
			}
			if (!(actionReference.Target is Action<TPayload>))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidDelegateRerefenceTypeException, new object[]
				{
					typeof(Action<TPayload>).FullName
				}), "actionReference");
			}
			if (filterReference == null)
			{
				throw new ArgumentNullException("filterReference");
			}
			if (!(filterReference.Target is Predicate<TPayload>))
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidDelegateRerefenceTypeException, new object[]
				{
					typeof(Predicate<TPayload>).FullName
				}), "filterReference");
			}
			this._actionReference = actionReference;
			this._filterReference = filterReference;
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002C8B File Offset: 0x00000E8B
		public Action<TPayload> Action
		{
			get
			{
				return (Action<TPayload>)this._actionReference.Target;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002C9D File Offset: 0x00000E9D
		public Predicate<TPayload> Filter
		{
			get
			{
				return (Predicate<TPayload>)this._filterReference.Target;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002CAF File Offset: 0x00000EAF
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002CB7 File Offset: 0x00000EB7
		public SubscriptionToken SubscriptionToken { get; set; }

		// Token: 0x0600005A RID: 90 RVA: 0x00002CC0 File Offset: 0x00000EC0
		public virtual Action<object[]> GetExecutionStrategy()
		{
			Action<TPayload> action = this.Action;
			Predicate<TPayload> filter = this.Filter;
			if (action != null && filter != null)
			{
				return delegate(object[] arguments)
				{
					TPayload tpayload = default(TPayload);
					if (arguments != null && arguments.Length != 0 && arguments[0] != null)
					{
						tpayload = (TPayload)((object)arguments[0]);
					}
					if (filter(tpayload))
					{
						this.InvokeAction(action, tpayload);
					}
				};
			}
			return null;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002D10 File Offset: 0x00000F10
		public virtual void InvokeAction(Action<TPayload> action, TPayload argument)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			action(argument);
		}

		// Token: 0x04000023 RID: 35
		private readonly IDelegateReference _actionReference;

		// Token: 0x04000024 RID: 36
		private readonly IDelegateReference _filterReference;
	}
}
