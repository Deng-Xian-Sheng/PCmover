using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002AB RID: 683
	internal struct CRYPT_OID_INFO
	{
		// Token: 0x04000D7E RID: 3454
		internal int cbSize;

		// Token: 0x04000D7F RID: 3455
		[MarshalAs(UnmanagedType.LPStr)]
		internal string pszOID;

		// Token: 0x04000D80 RID: 3456
		[MarshalAs(UnmanagedType.LPWStr)]
		internal string pwszName;

		// Token: 0x04000D81 RID: 3457
		internal OidGroup dwGroupId;

		// Token: 0x04000D82 RID: 3458
		internal int AlgId;

		// Token: 0x04000D83 RID: 3459
		internal int cbData;

		// Token: 0x04000D84 RID: 3460
		internal IntPtr pbData;
	}
}
