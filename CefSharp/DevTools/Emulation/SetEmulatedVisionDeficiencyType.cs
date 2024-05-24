using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x0200035B RID: 859
	public enum SetEmulatedVisionDeficiencyType
	{
		// Token: 0x04000DBA RID: 3514
		[EnumMember(Value = "none")]
		None,
		// Token: 0x04000DBB RID: 3515
		[EnumMember(Value = "achromatopsia")]
		Achromatopsia,
		// Token: 0x04000DBC RID: 3516
		[EnumMember(Value = "blurredVision")]
		BlurredVision,
		// Token: 0x04000DBD RID: 3517
		[EnumMember(Value = "deuteranopia")]
		Deuteranopia,
		// Token: 0x04000DBE RID: 3518
		[EnumMember(Value = "protanopia")]
		Protanopia,
		// Token: 0x04000DBF RID: 3519
		[EnumMember(Value = "tritanopia")]
		Tritanopia
	}
}
