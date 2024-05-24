using System;
using System.Threading.Tasks;

namespace Prism.Events
{
	// Token: 0x0200000E RID: 14
	public class BackgroundEventSubscription<TPayload> : EventSubscription<TPayload>
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00002656 File Offset: 0x00000856
		public BackgroundEventSubscription(IDelegateReference actionReference, IDelegateReference filterReference) : base(actionReference, filterReference)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002660 File Offset: 0x00000860
		public override void InvokeAction(Action<TPayload> action, TPayload argument)
		{
			Task.Run(delegate()
			{
				action(argument);
			});
		}
	}
}
