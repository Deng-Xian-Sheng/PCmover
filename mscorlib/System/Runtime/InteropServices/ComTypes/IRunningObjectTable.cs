using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A33 RID: 2611
	[Guid("00000010-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[__DynamicallyInvokable]
	[ComImport]
	public interface IRunningObjectTable
	{
		// Token: 0x06006657 RID: 26199
		[__DynamicallyInvokable]
		int Register(int grfFlags, [MarshalAs(UnmanagedType.Interface)] object punkObject, IMoniker pmkObjectName);

		// Token: 0x06006658 RID: 26200
		[__DynamicallyInvokable]
		void Revoke(int dwRegister);

		// Token: 0x06006659 RID: 26201
		[__DynamicallyInvokable]
		[PreserveSig]
		int IsRunning(IMoniker pmkObjectName);

		// Token: 0x0600665A RID: 26202
		[__DynamicallyInvokable]
		[PreserveSig]
		int GetObject(IMoniker pmkObjectName, [MarshalAs(UnmanagedType.Interface)] out object ppunkObject);

		// Token: 0x0600665B RID: 26203
		[__DynamicallyInvokable]
		void NoteChangeTime(int dwRegister, ref FILETIME pfiletime);

		// Token: 0x0600665C RID: 26204
		[__DynamicallyInvokable]
		[PreserveSig]
		int GetTimeOfLastChange(IMoniker pmkObjectName, out FILETIME pfiletime);

		// Token: 0x0600665D RID: 26205
		[__DynamicallyInvokable]
		void EnumRunning(out IEnumMoniker ppenumMoniker);
	}
}
