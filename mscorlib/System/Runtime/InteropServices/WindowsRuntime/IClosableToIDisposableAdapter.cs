using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009FB RID: 2555
	[SecurityCritical]
	internal sealed class IClosableToIDisposableAdapter
	{
		// Token: 0x060064E9 RID: 25833 RVA: 0x00157BE2 File Offset: 0x00155DE2
		private IClosableToIDisposableAdapter()
		{
		}

		// Token: 0x060064EA RID: 25834 RVA: 0x00157BEC File Offset: 0x00155DEC
		[SecurityCritical]
		private void Dispose()
		{
			IClosable closable = JitHelpers.UnsafeCast<IClosable>(this);
			closable.Close();
		}
	}
}
