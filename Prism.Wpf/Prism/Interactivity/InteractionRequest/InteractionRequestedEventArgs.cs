using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000078 RID: 120
	public class InteractionRequestedEventArgs : EventArgs
	{
		// Token: 0x06000384 RID: 900 RVA: 0x00009206 File Offset: 0x00007406
		public InteractionRequestedEventArgs(INotification context, Action callback)
		{
			this.Context = context;
			this.Callback = callback;
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000921C File Offset: 0x0000741C
		// (set) Token: 0x06000386 RID: 902 RVA: 0x00009224 File Offset: 0x00007424
		public INotification Context { get; private set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000922D File Offset: 0x0000742D
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00009235 File Offset: 0x00007435
		public Action Callback { get; private set; }
	}
}
