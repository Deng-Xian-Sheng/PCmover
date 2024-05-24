using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x0200007A RID: 122
	public class Notification : INotification
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000924D File Offset: 0x0000744D
		// (set) Token: 0x0600038C RID: 908 RVA: 0x00009255 File Offset: 0x00007455
		public string Title { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000925E File Offset: 0x0000745E
		// (set) Token: 0x0600038E RID: 910 RVA: 0x00009266 File Offset: 0x00007466
		public object Content { get; set; }
	}
}
