using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.StubHelpers;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009ED RID: 2541
	internal sealed class IterableToEnumerableAdapter
	{
		// Token: 0x060064AD RID: 25773 RVA: 0x00156FD3 File Offset: 0x001551D3
		private IterableToEnumerableAdapter()
		{
		}

		// Token: 0x060064AE RID: 25774 RVA: 0x00156FDC File Offset: 0x001551DC
		[SecurityCritical]
		internal IEnumerator<T> GetEnumerator_Stub<T>()
		{
			IIterable<T> iterable = JitHelpers.UnsafeCast<IIterable<T>>(this);
			return new IteratorToEnumeratorAdapter<T>(iterable.First());
		}

		// Token: 0x060064AF RID: 25775 RVA: 0x00156FFC File Offset: 0x001551FC
		[SecurityCritical]
		internal IEnumerator<T> GetEnumerator_Variance_Stub<T>() where T : class
		{
			bool flag;
			Delegate targetForAmbiguousVariantCall = StubHelpers.GetTargetForAmbiguousVariantCall(this, typeof(IEnumerable<T>).TypeHandle.Value, out flag);
			if (targetForAmbiguousVariantCall != null)
			{
				return JitHelpers.UnsafeCast<GetEnumerator_Delegate<T>>(targetForAmbiguousVariantCall)();
			}
			if (flag)
			{
				return JitHelpers.UnsafeCast<IEnumerator<T>>(this.GetEnumerator_Stub<string>());
			}
			return this.GetEnumerator_Stub<T>();
		}
	}
}
