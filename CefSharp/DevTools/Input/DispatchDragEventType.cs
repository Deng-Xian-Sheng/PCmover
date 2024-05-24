using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Input
{
	// Token: 0x02000335 RID: 821
	public enum DispatchDragEventType
	{
		// Token: 0x04000D44 RID: 3396
		[EnumMember(Value = "dragEnter")]
		DragEnter,
		// Token: 0x04000D45 RID: 3397
		[EnumMember(Value = "dragOver")]
		DragOver,
		// Token: 0x04000D46 RID: 3398
		[EnumMember(Value = "drop")]
		Drop,
		// Token: 0x04000D47 RID: 3399
		[EnumMember(Value = "dragCancel")]
		DragCancel
	}
}
