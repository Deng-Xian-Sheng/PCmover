using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200098A RID: 2442
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IRunningObjectTable instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("00000010-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIRunningObjectTable
	{
		// Token: 0x060062C4 RID: 25284
		void Register(int grfFlags, [MarshalAs(UnmanagedType.Interface)] object punkObject, UCOMIMoniker pmkObjectName, out int pdwRegister);

		// Token: 0x060062C5 RID: 25285
		void Revoke(int dwRegister);

		// Token: 0x060062C6 RID: 25286
		void IsRunning(UCOMIMoniker pmkObjectName);

		// Token: 0x060062C7 RID: 25287
		void GetObject(UCOMIMoniker pmkObjectName, [MarshalAs(UnmanagedType.Interface)] out object ppunkObject);

		// Token: 0x060062C8 RID: 25288
		void NoteChangeTime(int dwRegister, ref FILETIME pfiletime);

		// Token: 0x060062C9 RID: 25289
		void GetTimeOfLastChange(UCOMIMoniker pmkObjectName, out FILETIME pfiletime);

		// Token: 0x060062CA RID: 25290
		void EnumRunning(out UCOMIEnumMoniker ppenumMoniker);
	}
}
