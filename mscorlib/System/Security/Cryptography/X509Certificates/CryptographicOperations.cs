using System;
using System.Runtime.CompilerServices;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B7 RID: 695
	internal static class CryptographicOperations
	{
		// Token: 0x060024EA RID: 9450 RVA: 0x0008588F File Offset: 0x00083A8F
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static void ZeroMemory(Span<byte> buffer)
		{
			buffer.Clear();
		}
	}
}
