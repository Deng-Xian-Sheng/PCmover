using System;

namespace ControlzEx.Standard
{
	// Token: 0x0200005B RID: 91
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct BLENDFUNCTION
	{
		// Token: 0x040004F8 RID: 1272
		public AC BlendOp;

		// Token: 0x040004F9 RID: 1273
		public byte BlendFlags;

		// Token: 0x040004FA RID: 1274
		public byte SourceConstantAlpha;

		// Token: 0x040004FB RID: 1275
		public AC AlphaFormat;
	}
}
