using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.StubHelpers
{
	// Token: 0x020005A9 RID: 1449
	[SecurityCritical]
	internal sealed class CleanupWorkListElement
	{
		// Token: 0x06004328 RID: 17192 RVA: 0x000FA265 File Offset: 0x000F8465
		public CleanupWorkListElement(SafeHandle handle)
		{
			this.m_handle = handle;
		}

		// Token: 0x04001BE4 RID: 7140
		public SafeHandle m_handle;

		// Token: 0x04001BE5 RID: 7141
		public bool m_owned;
	}
}
