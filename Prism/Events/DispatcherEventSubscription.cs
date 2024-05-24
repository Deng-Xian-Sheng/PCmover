using System;
using System.Threading;

namespace Prism.Events
{
	// Token: 0x02000011 RID: 17
	public class DispatcherEventSubscription : EventSubscription
	{
		// Token: 0x06000040 RID: 64 RVA: 0x0000275C File Offset: 0x0000095C
		public DispatcherEventSubscription(IDelegateReference actionReference, SynchronizationContext context) : base(actionReference)
		{
			this.syncContext = context;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000276C File Offset: 0x0000096C
		public override void InvokeAction(Action action)
		{
			this.syncContext.Post(delegate(object o)
			{
				action();
			}, null);
		}

		// Token: 0x0400001B RID: 27
		private readonly SynchronizationContext syncContext;
	}
}
