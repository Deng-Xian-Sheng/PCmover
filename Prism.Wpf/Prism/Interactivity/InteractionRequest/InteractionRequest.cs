using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000077 RID: 119
	public class InteractionRequest<T> : IInteractionRequest where T : INotification
	{
		// Token: 0x14000018 RID: 24
		// (add) Token: 0x0600037F RID: 895 RVA: 0x00009120 File Offset: 0x00007320
		// (remove) Token: 0x06000380 RID: 896 RVA: 0x00009158 File Offset: 0x00007358
		public event EventHandler<InteractionRequestedEventArgs> Raised;

		// Token: 0x06000381 RID: 897 RVA: 0x0000918D File Offset: 0x0000738D
		public void Raise(T context)
		{
			this.Raise(context, delegate(T c)
			{
			});
		}

		// Token: 0x06000382 RID: 898 RVA: 0x000091B8 File Offset: 0x000073B8
		public void Raise(T context, Action<T> callback)
		{
			EventHandler<InteractionRequestedEventArgs> raised = this.Raised;
			if (raised != null)
			{
				raised(this, new InteractionRequestedEventArgs(context, delegate()
				{
					if (callback != null)
					{
						callback(context);
					}
				}));
			}
		}
	}
}
