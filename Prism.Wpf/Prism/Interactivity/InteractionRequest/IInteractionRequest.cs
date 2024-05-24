using System;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000074 RID: 116
	public interface IInteractionRequest
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000375 RID: 885
		// (remove) Token: 0x06000376 RID: 886
		event EventHandler<InteractionRequestedEventArgs> Raised;
	}
}
