using System;

namespace System.Collections.Concurrent
{
	// Token: 0x020004AF RID: 1199
	internal struct VolatileBool
	{
		// Token: 0x06003988 RID: 14728 RVA: 0x000DC74F File Offset: 0x000DA94F
		public VolatileBool(bool value)
		{
			this.m_value = value;
		}

		// Token: 0x04001924 RID: 6436
		public volatile bool m_value;
	}
}
