using System;
using System.Threading.Tasks;

namespace Prism.Events
{
	// Token: 0x0200000D RID: 13
	public class BackgroundEventSubscription : EventSubscription
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002644 File Offset: 0x00000844
		public BackgroundEventSubscription(IDelegateReference actionReference) : base(actionReference)
		{
		}

		// Token: 0x06000038 RID: 56 RVA: 0x0000264D File Offset: 0x0000084D
		public override void InvokeAction(Action action)
		{
			Task.Run(action);
		}
	}
}
