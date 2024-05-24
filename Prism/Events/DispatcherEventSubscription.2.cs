using System;
using System.Threading;

namespace Prism.Events
{
	// Token: 0x02000012 RID: 18
	public class DispatcherEventSubscription<TPayload> : EventSubscription<TPayload>
	{
		// Token: 0x06000042 RID: 66 RVA: 0x0000279E File Offset: 0x0000099E
		public DispatcherEventSubscription(IDelegateReference actionReference, IDelegateReference filterReference, SynchronizationContext context) : base(actionReference, filterReference)
		{
			this.syncContext = context;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000027B0 File Offset: 0x000009B0
		public override void InvokeAction(Action<TPayload> action, TPayload argument)
		{
			this.syncContext.Post(delegate(object o)
			{
				action((TPayload)((object)o));
			}, argument);
		}

		// Token: 0x0400001C RID: 28
		private readonly SynchronizationContext syncContext;
	}
}
