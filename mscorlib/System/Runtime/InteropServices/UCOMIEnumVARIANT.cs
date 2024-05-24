using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000984 RID: 2436
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumVARIANT instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00020404-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIEnumVARIANT
	{
		// Token: 0x06006296 RID: 25238
		[PreserveSig]
		int Next(int celt, int rgvar, int pceltFetched);

		// Token: 0x06006297 RID: 25239
		[PreserveSig]
		int Skip(int celt);

		// Token: 0x06006298 RID: 25240
		[PreserveSig]
		int Reset();

		// Token: 0x06006299 RID: 25241
		void Clone(int ppenum);
	}
}
