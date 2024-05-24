using System;
using System.Collections.Generic;

namespace System.Threading
{
	// Token: 0x02000540 RID: 1344
	internal sealed class SystemThreading_ThreadLocalDebugView<T>
	{
		// Token: 0x06003EFA RID: 16122 RVA: 0x000EA66B File Offset: 0x000E886B
		public SystemThreading_ThreadLocalDebugView(ThreadLocal<T> tlocal)
		{
			this.m_tlocal = tlocal;
		}

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06003EFB RID: 16123 RVA: 0x000EA67A File Offset: 0x000E887A
		public bool IsValueCreated
		{
			get
			{
				return this.m_tlocal.IsValueCreated;
			}
		}

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x06003EFC RID: 16124 RVA: 0x000EA687 File Offset: 0x000E8887
		public T Value
		{
			get
			{
				return this.m_tlocal.ValueForDebugDisplay;
			}
		}

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x06003EFD RID: 16125 RVA: 0x000EA694 File Offset: 0x000E8894
		public List<T> Values
		{
			get
			{
				return this.m_tlocal.ValuesForDebugDisplay;
			}
		}

		// Token: 0x04001A78 RID: 6776
		private readonly ThreadLocal<T> m_tlocal;
	}
}
