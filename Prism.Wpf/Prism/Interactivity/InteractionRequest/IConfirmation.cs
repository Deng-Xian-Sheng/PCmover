using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000073 RID: 115
	public interface IConfirmation : INotification
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000373 RID: 883
		// (set) Token: 0x06000374 RID: 884
		bool Confirmed { get; set; }
	}
}
