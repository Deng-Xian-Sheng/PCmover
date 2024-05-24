using System;

namespace zz93
{
	// Token: 0x02000168 RID: 360
	internal struct i4
	{
		// Token: 0x06000D2B RID: 3371 RVA: 0x00097BC1 File Offset: 0x00096BC1
		internal i4(i2 A_0, float A_1)
		{
			this.b = A_1;
			this.a = A_0;
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00097BD4 File Offset: 0x00096BD4
		internal float a()
		{
			return this.b;
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x00097BEC File Offset: 0x00096BEC
		internal void a(float A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00097BF8 File Offset: 0x00096BF8
		internal i2 b()
		{
			return this.a;
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x00097C10 File Offset: 0x00096C10
		internal void a(i2 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x040006C0 RID: 1728
		private i2 a;

		// Token: 0x040006C1 RID: 1729
		private float b;
	}
}
