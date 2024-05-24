using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000072 RID: 114
	public class Confirmation : Notification, IConfirmation, INotification
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00009107 File Offset: 0x00007307
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0000910F File Offset: 0x0000730F
		public bool Confirmed { get; set; }
	}
}
