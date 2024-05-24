using System;

namespace System.Reflection
{
	// Token: 0x020005F1 RID: 1521
	internal sealed class LoaderAllocator
	{
		// Token: 0x0600466E RID: 18030 RVA: 0x00102660 File Offset: 0x00100860
		private LoaderAllocator()
		{
			this.m_slots = new object[5];
			this.m_scout = new LoaderAllocatorScout();
		}

		// Token: 0x04001CCD RID: 7373
		private LoaderAllocatorScout m_scout;

		// Token: 0x04001CCE RID: 7374
		private object[] m_slots;

		// Token: 0x04001CCF RID: 7375
		internal CerHashtable<RuntimeMethodInfo, RuntimeMethodInfo> m_methodInstantiations;

		// Token: 0x04001CD0 RID: 7376
		private int m_slotsUsed;
	}
}
