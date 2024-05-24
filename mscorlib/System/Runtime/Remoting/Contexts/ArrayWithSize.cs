using System;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000810 RID: 2064
	internal class ArrayWithSize
	{
		// Token: 0x060058D4 RID: 22740 RVA: 0x001391D2 File Offset: 0x001373D2
		internal ArrayWithSize(IDynamicMessageSink[] sinks, int count)
		{
			this.Sinks = sinks;
			this.Count = count;
		}

		// Token: 0x04002872 RID: 10354
		internal IDynamicMessageSink[] Sinks;

		// Token: 0x04002873 RID: 10355
		internal int Count;
	}
}
