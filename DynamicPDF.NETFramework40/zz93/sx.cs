using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x020002D5 RID: 725
	[DefaultMember("Item")]
	internal class sx
	{
		// Token: 0x060020B1 RID: 8369 RVA: 0x001411C4 File Offset: 0x001401C4
		internal sx(rm A_0, vq A_1)
		{
			this.a = new sw[A_1.a()];
			int num = 0;
			for (vp vp = A_1.b(); vp != null; vp = vp.a())
			{
				this.a[num++] = new sw(A_0, vp);
			}
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x00141220 File Offset: 0x00140220
		internal sx(rm A_0, vq A_1, ref bool A_2)
		{
			this.a = new sw[A_1.a()];
			int num = 0;
			for (vp vp = A_1.b(); vp != null; vp = vp.a())
			{
				if (!A_2)
				{
					A_2 = (vp.f() != null);
				}
				this.a[num++] = new sw(A_0, vp);
			}
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x00141290 File Offset: 0x00140290
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x001412AC File Offset: 0x001402AC
		internal sw a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x04000E5C RID: 3676
		private sw[] a;
	}
}
