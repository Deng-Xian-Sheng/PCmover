using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A35 RID: 2613
	[Guid("0000000c-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IStream
	{
		// Token: 0x0600665E RID: 26206
		void Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] byte[] pv, int cb, IntPtr pcbRead);

		// Token: 0x0600665F RID: 26207
		void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);

		// Token: 0x06006660 RID: 26208
		void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

		// Token: 0x06006661 RID: 26209
		[__DynamicallyInvokable]
		void SetSize(long libNewSize);

		// Token: 0x06006662 RID: 26210
		void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

		// Token: 0x06006663 RID: 26211
		[__DynamicallyInvokable]
		void Commit(int grfCommitFlags);

		// Token: 0x06006664 RID: 26212
		[__DynamicallyInvokable]
		void Revert();

		// Token: 0x06006665 RID: 26213
		[__DynamicallyInvokable]
		void LockRegion(long libOffset, long cb, int dwLockType);

		// Token: 0x06006666 RID: 26214
		[__DynamicallyInvokable]
		void UnlockRegion(long libOffset, long cb, int dwLockType);

		// Token: 0x06006667 RID: 26215
		[__DynamicallyInvokable]
		void Stat(out STATSTG pstatstg, int grfStatFlag);

		// Token: 0x06006668 RID: 26216
		[__DynamicallyInvokable]
		void Clone(out IStream ppstm);
	}
}
