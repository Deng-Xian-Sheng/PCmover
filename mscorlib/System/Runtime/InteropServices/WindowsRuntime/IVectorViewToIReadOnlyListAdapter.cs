using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using System.StubHelpers;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009E9 RID: 2537
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class IVectorViewToIReadOnlyListAdapter
	{
		// Token: 0x0600649B RID: 25755 RVA: 0x00156CBF File Offset: 0x00154EBF
		private IVectorViewToIReadOnlyListAdapter()
		{
		}

		// Token: 0x0600649C RID: 25756 RVA: 0x00156CC8 File Offset: 0x00154EC8
		[SecurityCritical]
		internal T Indexer_Get<T>(int index)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			IVectorView<T> vectorView = JitHelpers.UnsafeCast<IVectorView<T>>(this);
			T at;
			try
			{
				at = vectorView.GetAt((uint)index);
			}
			catch (Exception ex)
			{
				if (-2147483637 == ex._HResult)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				throw;
			}
			return at;
		}

		// Token: 0x0600649D RID: 25757 RVA: 0x00156D24 File Offset: 0x00154F24
		[SecurityCritical]
		internal T Indexer_Get_Variance<T>(int index) where T : class
		{
			bool flag;
			Delegate targetForAmbiguousVariantCall = StubHelpers.GetTargetForAmbiguousVariantCall(this, typeof(IReadOnlyList<T>).TypeHandle.Value, out flag);
			if (targetForAmbiguousVariantCall != null)
			{
				return JitHelpers.UnsafeCast<Indexer_Get_Delegate<T>>(targetForAmbiguousVariantCall)(index);
			}
			if (flag)
			{
				return JitHelpers.UnsafeCast<T>(this.Indexer_Get<string>(index));
			}
			return this.Indexer_Get<T>(index);
		}
	}
}
