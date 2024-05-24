using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200042E RID: 1070
	internal class EventDispatcher
	{
		// Token: 0x06003569 RID: 13673 RVA: 0x000CF0BA File Offset: 0x000CD2BA
		internal EventDispatcher(EventDispatcher next, bool[] eventEnabled, EventListener listener)
		{
			this.m_Next = next;
			this.m_EventEnabled = eventEnabled;
			this.m_Listener = listener;
		}

		// Token: 0x040017BB RID: 6075
		internal readonly EventListener m_Listener;

		// Token: 0x040017BC RID: 6076
		internal bool[] m_EventEnabled;

		// Token: 0x040017BD RID: 6077
		internal bool m_activityFilteringEnabled;

		// Token: 0x040017BE RID: 6078
		internal EventDispatcher m_Next;
	}
}
