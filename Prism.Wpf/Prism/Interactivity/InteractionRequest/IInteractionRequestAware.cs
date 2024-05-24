using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000075 RID: 117
	public interface IInteractionRequestAware
	{
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000377 RID: 887
		// (set) Token: 0x06000378 RID: 888
		INotification Notification { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000379 RID: 889
		// (set) Token: 0x0600037A RID: 890
		Action FinishInteraction { get; set; }
	}
}
