using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CertificateServer
{
	// Token: 0x02000008 RID: 8
	[CompilerGenerated]
	[Guid("6A08CFC8-D0DF-4ECC-9888-141AAC4AB5ED")]
	[TypeIdentifier]
	[ComImport]
	public interface ICertificateContext
	{
		// Token: 0x06000015 RID: 21
		void _VtblGap1_1();

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000016 RID: 22
		[DispId(2)]
		string CommonName { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
