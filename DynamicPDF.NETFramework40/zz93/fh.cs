using System;

namespace zz93
{
	// Token: 0x020000E5 RID: 229
	internal class fh : fd
	{
		// Token: 0x06000A39 RID: 2617 RVA: 0x00083FDE File Offset: 0x00082FDE
		internal fh()
		{
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x00083FE9 File Offset: 0x00082FE9
		internal fh(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00083FFC File Offset: 0x00082FFC
		internal im a()
		{
			return this.a;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00084014 File Offset: 0x00083014
		internal override int cv()
		{
			return 1352615981;
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0008402C File Offset: 0x0008302C
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00084044 File Offset: 0x00083044
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 != 27497991)
			{
				if (num2 != 503783202)
				{
					if (num2 == 505607249)
					{
						this.a = new im(il.a);
						this.a.d(true);
					}
				}
				else
				{
					this.a = new im(il.a);
				}
			}
			else
			{
				this.a = new im(il.b);
			}
		}

		// Token: 0x04000511 RID: 1297
		private new im a;
	}
}
