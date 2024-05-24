using System;

namespace ControlzEx.Standard
{
	// Token: 0x02000078 RID: 120
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public struct WINDOWPOS
	{
		// Token: 0x060001BF RID: 447 RVA: 0x00008E44 File Offset: 0x00007044
		public override string ToString()
		{
			return string.Format("x: {0}; y: {1}; cx: {2}; cy: {3}; flags: {4}", new object[]
			{
				this.x,
				this.y,
				this.cx,
				this.cy,
				this.flags
			});
		}

		// Token: 0x040005A5 RID: 1445
		public IntPtr hwnd;

		// Token: 0x040005A6 RID: 1446
		public IntPtr hwndInsertAfter;

		// Token: 0x040005A7 RID: 1447
		public int x;

		// Token: 0x040005A8 RID: 1448
		public int y;

		// Token: 0x040005A9 RID: 1449
		public int cx;

		// Token: 0x040005AA RID: 1450
		public int cy;

		// Token: 0x040005AB RID: 1451
		public SWP flags;
	}
}
