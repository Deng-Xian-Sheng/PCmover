using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x02000670 RID: 1648
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("285a8861-c84a-11d7-850f-005cd062464f")]
	[ComImport]
	internal interface ISectionEntry
	{
		// Token: 0x06004F1E RID: 20254
		object GetField(uint fieldId);

		// Token: 0x06004F1F RID: 20255
		string GetFieldName(uint fieldId);
	}
}
