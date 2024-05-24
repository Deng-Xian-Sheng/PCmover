using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x0200031F RID: 799
	public enum ScrollRectType
	{
		// Token: 0x04000CFC RID: 3324
		[EnumMember(Value = "RepaintsOnScroll")]
		RepaintsOnScroll,
		// Token: 0x04000CFD RID: 3325
		[EnumMember(Value = "TouchEventHandler")]
		TouchEventHandler,
		// Token: 0x04000CFE RID: 3326
		[EnumMember(Value = "WheelEventHandler")]
		WheelEventHandler
	}
}
