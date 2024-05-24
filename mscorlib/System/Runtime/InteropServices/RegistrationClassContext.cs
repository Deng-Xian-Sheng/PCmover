using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000973 RID: 2419
	[Flags]
	public enum RegistrationClassContext
	{
		// Token: 0x04002BB4 RID: 11188
		InProcessServer = 1,
		// Token: 0x04002BB5 RID: 11189
		InProcessHandler = 2,
		// Token: 0x04002BB6 RID: 11190
		LocalServer = 4,
		// Token: 0x04002BB7 RID: 11191
		InProcessServer16 = 8,
		// Token: 0x04002BB8 RID: 11192
		RemoteServer = 16,
		// Token: 0x04002BB9 RID: 11193
		InProcessHandler16 = 32,
		// Token: 0x04002BBA RID: 11194
		Reserved1 = 64,
		// Token: 0x04002BBB RID: 11195
		Reserved2 = 128,
		// Token: 0x04002BBC RID: 11196
		Reserved3 = 256,
		// Token: 0x04002BBD RID: 11197
		Reserved4 = 512,
		// Token: 0x04002BBE RID: 11198
		NoCodeDownload = 1024,
		// Token: 0x04002BBF RID: 11199
		Reserved5 = 2048,
		// Token: 0x04002BC0 RID: 11200
		NoCustomMarshal = 4096,
		// Token: 0x04002BC1 RID: 11201
		EnableCodeDownload = 8192,
		// Token: 0x04002BC2 RID: 11202
		NoFailureLog = 16384,
		// Token: 0x04002BC3 RID: 11203
		DisableActivateAsActivator = 32768,
		// Token: 0x04002BC4 RID: 11204
		EnableActivateAsActivator = 65536,
		// Token: 0x04002BC5 RID: 11205
		FromDefaultContext = 131072
	}
}
