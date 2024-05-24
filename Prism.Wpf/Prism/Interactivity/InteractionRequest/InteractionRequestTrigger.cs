using System;
using System.Windows.Interactivity;

namespace Prism.Interactivity.InteractionRequest
{
	// Token: 0x02000079 RID: 121
	public class InteractionRequestTrigger : EventTrigger
	{
		// Token: 0x06000389 RID: 905 RVA: 0x0000923E File Offset: 0x0000743E
		protected override string GetEventName()
		{
			return "Raised";
		}
	}
}
