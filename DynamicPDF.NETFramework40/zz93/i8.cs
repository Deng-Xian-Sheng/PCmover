using System;

namespace zz93
{
	// Token: 0x0200016C RID: 364
	internal class i8 : fd
	{
		// Token: 0x06000D42 RID: 3394 RVA: 0x00098034 File Offset: 0x00097034
		internal i8()
		{
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0009803F File Offset: 0x0009703F
		internal i8(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x00098054 File Offset: 0x00097054
		internal i9 a()
		{
			return this.a;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0009806C File Offset: 0x0009706C
		internal void a(i9 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x00098078 File Offset: 0x00097078
		internal override int cv()
		{
			return 40160150;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x00098090 File Offset: 0x00097090
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x000980A8 File Offset: 0x000970A8
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			if (num != 34721)
			{
				if (num != 24798759)
				{
					if (num != 505607249)
					{
						this.a = new i9(gu.a);
					}
					else
					{
						this.a = new i9(gu.a);
						this.a.d(true);
					}
				}
				else
				{
					this.a = new i9(gu.b);
				}
			}
			else
			{
				this.a = new i9(gu.c);
			}
		}

		// Token: 0x040006C7 RID: 1735
		private new i9 a;
	}
}
