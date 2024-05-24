using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000294 RID: 660
	public enum ColorFormat
	{
		// Token: 0x04000A65 RID: 2661
		[EnumMember(Value = "rgb")]
		Rgb,
		// Token: 0x04000A66 RID: 2662
		[EnumMember(Value = "hsl")]
		Hsl,
		// Token: 0x04000A67 RID: 2663
		[EnumMember(Value = "hex")]
		Hex
	}
}
