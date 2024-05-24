using System;

namespace System.Threading
{
	// Token: 0x02000545 RID: 1349
	internal struct CancellationCallbackCoreWorkArguments
	{
		// Token: 0x06003F63 RID: 16227 RVA: 0x000EC00C File Offset: 0x000EA20C
		public CancellationCallbackCoreWorkArguments(SparselyPopulatedArrayFragment<CancellationCallbackInfo> currArrayFragment, int currArrayIndex)
		{
			this.m_currArrayFragment = currArrayFragment;
			this.m_currArrayIndex = currArrayIndex;
		}

		// Token: 0x04001AA5 RID: 6821
		internal SparselyPopulatedArrayFragment<CancellationCallbackInfo> m_currArrayFragment;

		// Token: 0x04001AA6 RID: 6822
		internal int m_currArrayIndex;
	}
}
