using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200098C RID: 2444
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IStream instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("0000000c-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIStream
	{
		// Token: 0x060062CB RID: 25291
		void Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] byte[] pv, int cb, IntPtr pcbRead);

		// Token: 0x060062CC RID: 25292
		void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);

		// Token: 0x060062CD RID: 25293
		void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

		// Token: 0x060062CE RID: 25294
		void SetSize(long libNewSize);

		// Token: 0x060062CF RID: 25295
		void CopyTo(UCOMIStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

		// Token: 0x060062D0 RID: 25296
		void Commit(int grfCommitFlags);

		// Token: 0x060062D1 RID: 25297
		void Revert();

		// Token: 0x060062D2 RID: 25298
		void LockRegion(long libOffset, long cb, int dwLockType);

		// Token: 0x060062D3 RID: 25299
		void UnlockRegion(long libOffset, long cb, int dwLockType);

		// Token: 0x060062D4 RID: 25300
		void Stat(out STATSTG pstatstg, int grfStatFlag);

		// Token: 0x060062D5 RID: 25301
		void Clone(out UCOMIStream ppstm);
	}
}
