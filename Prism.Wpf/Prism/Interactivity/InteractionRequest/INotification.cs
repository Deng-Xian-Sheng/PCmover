using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000076 RID: 118
	public interface INotification
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600037B RID: 891
		// (set) Token: 0x0600037C RID: 892
		string Title { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600037D RID: 893
		// (set) Token: 0x0600037E RID: 894
		object Content { get; set; }
	}
}
