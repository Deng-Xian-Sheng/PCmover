using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000117 RID: 279
	internal class MessageListenerFilterRegistrationResult
	{
		// Token: 0x06000C3D RID: 3133 RVA: 0x0002EE8E File Offset: 0x0002D08E
		internal MessageListenerFilterRegistrationResult(IntPtr handle, uint msg)
		{
			this.WindowHandle = handle;
			this.Message = msg;
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x0002EEAC File Offset: 0x0002D0AC
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x0002EEC3 File Offset: 0x0002D0C3
		public IntPtr WindowHandle { get; private set; }

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x0002EECC File Offset: 0x0002D0CC
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x0002EEE3 File Offset: 0x0002D0E3
		public uint Message { get; private set; }
	}
}
