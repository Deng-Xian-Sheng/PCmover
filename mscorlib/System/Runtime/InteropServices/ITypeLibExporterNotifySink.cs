using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200096F RID: 2415
	[Guid("F1C3BF77-C3E4-11d3-88E7-00902754C43A")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ITypeLibExporterNotifySink
	{
		// Token: 0x06006231 RID: 25137
		void ReportEvent(ExporterEventKind eventKind, int eventCode, string eventMsg);

		// Token: 0x06006232 RID: 25138
		[return: MarshalAs(UnmanagedType.Interface)]
		object ResolveRef(Assembly assembly);
	}
}
