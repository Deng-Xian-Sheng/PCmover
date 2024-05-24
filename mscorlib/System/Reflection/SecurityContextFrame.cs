using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005DB RID: 1499
	internal struct SecurityContextFrame
	{
		// Token: 0x06004568 RID: 17768
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Push(RuntimeAssembly assembly);

		// Token: 0x06004569 RID: 17769
		[SecurityCritical]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void Pop();

		// Token: 0x04001C7F RID: 7295
		private IntPtr m_GSCookie;

		// Token: 0x04001C80 RID: 7296
		private IntPtr __VFN_table;

		// Token: 0x04001C81 RID: 7297
		private IntPtr m_Next;

		// Token: 0x04001C82 RID: 7298
		private IntPtr m_Assembly;
	}
}
