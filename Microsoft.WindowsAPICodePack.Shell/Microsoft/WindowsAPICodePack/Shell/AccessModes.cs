using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200003C RID: 60
	[Flags]
	public enum AccessModes
	{
		// Token: 0x040000D7 RID: 215
		Direct = 0,
		// Token: 0x040000D8 RID: 216
		Transacted = 65536,
		// Token: 0x040000D9 RID: 217
		Simple = 134217728,
		// Token: 0x040000DA RID: 218
		Read = 0,
		// Token: 0x040000DB RID: 219
		Write = 1,
		// Token: 0x040000DC RID: 220
		ReadWrite = 2,
		// Token: 0x040000DD RID: 221
		ShareDenyNone = 64,
		// Token: 0x040000DE RID: 222
		ShareDenyRead = 48,
		// Token: 0x040000DF RID: 223
		ShareDenyWrite = 32,
		// Token: 0x040000E0 RID: 224
		ShareExclusive = 16,
		// Token: 0x040000E1 RID: 225
		Priority = 262144,
		// Token: 0x040000E2 RID: 226
		DeleteOnRelease = 67108864,
		// Token: 0x040000E3 RID: 227
		NoScratch = 1048576,
		// Token: 0x040000E4 RID: 228
		Create = 4096,
		// Token: 0x040000E5 RID: 229
		Convert = 131072,
		// Token: 0x040000E6 RID: 230
		FailIfThere = 0,
		// Token: 0x040000E7 RID: 231
		NoSnapshot = 2097152,
		// Token: 0x040000E8 RID: 232
		DirectSingleWriterMultipleReader = 4194304
	}
}
