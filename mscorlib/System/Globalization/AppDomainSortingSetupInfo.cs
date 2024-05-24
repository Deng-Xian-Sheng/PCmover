using System;

namespace System.Globalization
{
	// Token: 0x0200039F RID: 927
	internal sealed class AppDomainSortingSetupInfo
	{
		// Token: 0x06002D99 RID: 11673 RVA: 0x000AEA09 File Offset: 0x000ACC09
		internal AppDomainSortingSetupInfo()
		{
		}

		// Token: 0x06002D9A RID: 11674 RVA: 0x000AEA14 File Offset: 0x000ACC14
		internal AppDomainSortingSetupInfo(AppDomainSortingSetupInfo copy)
		{
			this._useV2LegacySorting = copy._useV2LegacySorting;
			this._useV4LegacySorting = copy._useV4LegacySorting;
			this._pfnIsNLSDefinedString = copy._pfnIsNLSDefinedString;
			this._pfnCompareStringEx = copy._pfnCompareStringEx;
			this._pfnLCMapStringEx = copy._pfnLCMapStringEx;
			this._pfnFindNLSStringEx = copy._pfnFindNLSStringEx;
			this._pfnFindStringOrdinal = copy._pfnFindStringOrdinal;
			this._pfnCompareStringOrdinal = copy._pfnCompareStringOrdinal;
			this._pfnGetNLSVersionEx = copy._pfnGetNLSVersionEx;
		}

		// Token: 0x0400128F RID: 4751
		internal IntPtr _pfnIsNLSDefinedString;

		// Token: 0x04001290 RID: 4752
		internal IntPtr _pfnCompareStringEx;

		// Token: 0x04001291 RID: 4753
		internal IntPtr _pfnLCMapStringEx;

		// Token: 0x04001292 RID: 4754
		internal IntPtr _pfnFindNLSStringEx;

		// Token: 0x04001293 RID: 4755
		internal IntPtr _pfnCompareStringOrdinal;

		// Token: 0x04001294 RID: 4756
		internal IntPtr _pfnGetNLSVersionEx;

		// Token: 0x04001295 RID: 4757
		internal IntPtr _pfnFindStringOrdinal;

		// Token: 0x04001296 RID: 4758
		internal bool _useV2LegacySorting;

		// Token: 0x04001297 RID: 4759
		internal bool _useV4LegacySorting;
	}
}
