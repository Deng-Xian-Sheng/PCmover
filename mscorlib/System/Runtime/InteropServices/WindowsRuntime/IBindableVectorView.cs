using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1C RID: 2588
	[Guid("346dd6e7-976e-4bc3-815d-ece243bc0f33")]
	[ComImport]
	internal interface IBindableVectorView : IBindableIterable
	{
		// Token: 0x060065EA RID: 26090
		object GetAt(uint index);

		// Token: 0x17001183 RID: 4483
		// (get) Token: 0x060065EB RID: 26091
		uint Size { get; }

		// Token: 0x060065EC RID: 26092
		bool IndexOf(object value, out uint index);
	}
}
