using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class ShellException : ExternalException
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002486 File Offset: 0x00000686
		public ShellException()
		{
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002491 File Offset: 0x00000691
		internal ShellException(HResult result) : this((int)result)
		{
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000249D File Offset: 0x0000069D
		public ShellException(string message) : base(message)
		{
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024A9 File Offset: 0x000006A9
		public ShellException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024B6 File Offset: 0x000006B6
		public ShellException(string message, int errorCode) : base(message, errorCode)
		{
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000024C3 File Offset: 0x000006C3
		internal ShellException(string message, HResult errorCode) : this(message, (int)errorCode)
		{
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000024D0 File Offset: 0x000006D0
		public ShellException(int errorCode) : base(LocalizedMessages.ShellExceptionDefaultText, errorCode)
		{
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000024E1 File Offset: 0x000006E1
		protected ShellException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
