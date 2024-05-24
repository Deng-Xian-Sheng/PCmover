using System;
using Microsoft.WindowsAPICodePack.Shell.Interop;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000114 RID: 276
	public class WindowMessageEventArgs : EventArgs
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x0002EAE4 File Offset: 0x0002CCE4
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x0002EAFB File Offset: 0x0002CCFB
		public Message Message { get; private set; }

		// Token: 0x06000C32 RID: 3122 RVA: 0x0002EB04 File Offset: 0x0002CD04
		internal WindowMessageEventArgs(Message msg)
		{
			this.Message = msg;
		}
	}
}
