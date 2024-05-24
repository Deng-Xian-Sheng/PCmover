using System;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B1 RID: 1969
	internal struct IdOps
	{
		// Token: 0x06005569 RID: 21865 RVA: 0x0012F5C6 File Offset: 0x0012D7C6
		internal static bool bStrongIdentity(int flags)
		{
			return (flags & 2) != 0;
		}

		// Token: 0x0600556A RID: 21866 RVA: 0x0012F5CE File Offset: 0x0012D7CE
		internal static bool bIsInitializing(int flags)
		{
			return (flags & 4) != 0;
		}

		// Token: 0x04002752 RID: 10066
		internal const int None = 0;

		// Token: 0x04002753 RID: 10067
		internal const int GenerateURI = 1;

		// Token: 0x04002754 RID: 10068
		internal const int StrongIdentity = 2;

		// Token: 0x04002755 RID: 10069
		internal const int IsInitializing = 4;
	}
}
