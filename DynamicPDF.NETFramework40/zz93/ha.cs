using System;

namespace zz93
{
	// Token: 0x02000126 RID: 294
	internal class ha : fd
	{
		// Token: 0x06000B47 RID: 2887 RVA: 0x0008A76C File Offset: 0x0008976C
		internal ha(gi A_0)
		{
			this.cw(A_0);
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0008A780 File Offset: 0x00089780
		internal override void cw(gi A_0)
		{
			int num = A_0.aj();
			int num2 = num;
			if (num2 != 2315247)
			{
				if (num2 != 10066912)
				{
					if (num2 != 505607249)
					{
						this.a = new hb(iq.b);
					}
					else
					{
						this.a = new hb(iq.b);
						this.a.d(true);
					}
				}
				else
				{
					this.a = new hb(iq.b);
				}
			}
			else
			{
				this.a = new hb(iq.a);
			}
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0008A7F8 File Offset: 0x000897F8
		internal hb a()
		{
			return this.a;
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0008A810 File Offset: 0x00089810
		internal override int cv()
		{
			return 2066421648;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0008A828 File Offset: 0x00089828
		internal override fn cx()
		{
			return this.a;
		}

		// Token: 0x04000606 RID: 1542
		private new hb a;
	}
}
