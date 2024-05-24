using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200096E RID: 2414
	[Guid("F1C3BF76-C3E4-11d3-88E7-00902754C43A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ITypeLibImporterNotifySink
	{
		// Token: 0x0600622F RID: 25135
		void ReportEvent(ImporterEventKind eventKind, int eventCode, string eventMsg);

		// Token: 0x06006230 RID: 25136
		Assembly ResolveRef([MarshalAs(UnmanagedType.Interface)] object typeLib);
	}
}
