using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009FA RID: 2554
	internal sealed class IDisposableToIClosableAdapter
	{
		// Token: 0x060064E7 RID: 25831 RVA: 0x00157BBF File Offset: 0x00155DBF
		private IDisposableToIClosableAdapter()
		{
		}

		// Token: 0x060064E8 RID: 25832 RVA: 0x00157BC8 File Offset: 0x00155DC8
		[SecurityCritical]
		public void Close()
		{
			IDisposable disposable = JitHelpers.UnsafeCast<IDisposable>(this);
			disposable.Dispose();
		}
	}
}
